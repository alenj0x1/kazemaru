using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;

namespace backend.Controllers.Contract;

public interface IAuthController
{
    Task<GenericResponse<string>> Login(LoginRequest request);
    Task<GenericResponse<string>> Refresh();
    Task<GenericResponse<bool>> Logout();
}