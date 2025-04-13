using backend.Entity.Postgres;
using backend.Entity.Redis;
using Task = System.Threading.Tasks.Task;

namespace backend.Services.Contract;

public interface ITokenService
{
    Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> CreateTokensAsync(User user); 
    Task<string?> GetAccessTokenAsync(string accessToken);
    Task<Session?> GetRefreshTokenAsync(string refreshToken);
    Task<(string NewAccessToken, DateTime ExpirationDate, string NewRefreshToken)> RefreshSessionAsync(Session session, User user);
    Task RevokeAllUserSessionsAsync(User user);
    Task RevokeSessionAsync(Session session);
}