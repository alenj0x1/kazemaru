using backend.Models.Response.Auth;
using Microsoft.AspNetCore.Identity.Data;

namespace backend.Services.Contract;

public interface IAuthService
{
    AuthResponse Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}