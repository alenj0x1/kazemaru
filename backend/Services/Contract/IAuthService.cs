using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;

namespace backend.Services.Contract;

public interface IAuthService
{
    GenericResponse<AuthResponse> Login(LoginRequest request);
}