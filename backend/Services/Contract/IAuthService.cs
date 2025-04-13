using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;

namespace backend.Services.Contract;

public interface IAuthService
{
    Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> Login(LoginRequest request);
    Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> Refresh(string refreshToken);
    Task Logout(string refreshToken);
}