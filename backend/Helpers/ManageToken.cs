using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Entity;
using Microsoft.IdentityModel.Tokens;

namespace backend.Helpers;

public class ManageToken(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public string CreateAccessToken(User user)
    {
        try
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("UserId", user.UserId.ToString()));

            var secretKey =
                new SymmetricSecurityKey((Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"] ??
                                                                 throw new Exception("Missing JWT Secret Key"))));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var expiresIn = Parser.ToDateTime(_configuration["JWT:ExpiresIn"] ??
                                            throw new Exception("Missing JWT Expires In") ??
                                                  throw new Exception("Incorrect JWT Expires In"));
            
            var token = new JwtSecurityToken(audience: _configuration["JWT:Audience"], issuer: _configuration["JWT:Issuer"],
                claims: claims.Claims, expires: expiresIn, signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}