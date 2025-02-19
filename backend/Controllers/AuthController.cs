using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;
    
    [HttpPost("login")]
    public GenericResponse<AuthResponse> Login([FromBody] LoginRequest request)
    {
        try
        {
            return _authService.Login(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}