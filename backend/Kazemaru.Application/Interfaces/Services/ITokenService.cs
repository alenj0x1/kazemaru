using Kazemaru.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Kazemaru.Application.Interfaces.Services;

public interface ITokenService
{
    Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> CreateTokensAsync(User user);
    Task<string?> GetAccessTokenAsync(string accessToken);
    Task<Session?> GetRefreshTokenAsync(string refreshToken);
    Task<(string NewAccessToken, DateTime ExpirationDate, string NewRefreshToken)> RefreshSessionAsync(Session session, User user);
    Task RevokeAllUserSessionsAsync(User user);
    Task RevokeSessionAsync(Session session);
}