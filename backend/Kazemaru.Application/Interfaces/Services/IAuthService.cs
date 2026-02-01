using backend.Kazemaru.Application.Models.Requests.Auth;

namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IAuthService
{
    Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> Login(LoginRequest request);
    Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> Refresh(string refreshToken);
    Task Logout(string refreshToken);
}