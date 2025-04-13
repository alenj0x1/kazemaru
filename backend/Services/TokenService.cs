using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using backend.Entity.Postgres;
using backend.Entity.Redis;
using backend.Services.Contract;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using Task = System.Threading.Tasks.Task;

namespace backend.Services;

public class TokenService(IConfiguration configuration, IConnectionMultiplexer redis) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> CreateTokensAsync(User user)
    {
        var accessToken = GenerateAccessToken(user);
        var refreshToken = GenerateRefreshToken();

        await StoreSessionAsync(user, refreshToken, accessToken.AccessToken);
        
        return (accessToken.AccessToken, accessToken.ExpirationDate,refreshToken);
    }
    
    public async Task<string?> GetAccessTokenAsync(string accessToken)
    {
        var data = await _db.StringGetAsync($"access:{accessToken}");
        return !data.HasValue ? null : data.ToString();
    }

    public async Task<Session?> GetRefreshTokenAsync(string refreshToken)
    {
        var data = await _db.StringGetAsync($"session:{refreshToken}");
        return !data.HasValue ? null : JsonSerializer.Deserialize<Session>(data.ToString());
    }

    public async Task<(string NewAccessToken, DateTime ExpirationDate, string NewRefreshToken)> RefreshSessionAsync(Session session, User user)
    {
        if (DateTime.UtcNow.Subtract(session.LastActivity).TotalDays > 30)
        {
            
            throw new SecurityTokenException("session expired for inactivity.");
        }
        
        await RevokeSessionAsync(session);
        
        var newAccessToken = GenerateAccessToken(user);
        var newRefreshToken = GenerateRefreshToken();
        
        await StoreSessionAsync(user, newRefreshToken, newAccessToken.AccessToken);

        return (newAccessToken.AccessToken, newAccessToken.ExpirationDate,  newRefreshToken);
    }

    public async Task RevokeAllUserSessionsAsync(User user)
    {
        var sessions = await _db.SetMembersAsync($"user:{user.UserId}:sessions");

        foreach (var refreshToken in sessions)
        {
            await _db.KeyDeleteAsync($"session:{refreshToken}");
        }

        await _db.KeyDeleteAsync($"user:{user.UserId}:sessions");
    }
    
    private (string AccessToken, DateTime ExpirationDate) GenerateAccessToken(User user)
    {
        try
        {
            var claims = new []
            {
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey((Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"] ?? throw new Exception("Missing JWT Secret Key"))));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = _configuration["JWT:ExpiresInMinutes"] ?? throw new Exception("Incorrect JWT ExpiresInMinutes");
            var expirationDate = DateTime.Now.AddMinutes(Convert.ToInt32(expiration));
            
            var token = new JwtSecurityToken(
                audience: _configuration["JWT:Audience"], 
                issuer: _configuration["JWT:Issuer"],
                claims: claims, 
                expires: expirationDate, 
                signingCredentials: credentials
            );
            
            return (new JwtSecurityTokenHandler().WriteToken(token), expirationDate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(randomNumber);
        
        return Convert.ToBase64String(randomNumber);
    }
    
    private async Task StoreSessionAsync(User user, string refreshToken, string accessToken)
    {
        await _db.StringSetAsync($"session:{refreshToken}", JsonSerializer.Serialize(new Session
        {
            RefreshToken = refreshToken,
            AccessToken = accessToken,
            UserId = user.UserId,
            LastActivity = DateTime.UtcNow
        }));
        
        await _db.StringSetAsync($"access:{accessToken}", accessToken, TimeSpan.FromMinutes(5));
        
        await _db.SetAddAsync($"user:{user.UserId}:sessions", refreshToken);
    }

    public async Task RevokeSessionAsync(Session session)
    {
        await _db.KeyDeleteAsync($"session:{session.RefreshToken}");
        await _db.KeyDeleteAsync($"access:{session.AccessToken}");
        
        await _db.SetRemoveAsync($"user:{session.UserId}:sessions", session.RefreshToken);
    }
}