using backend.Controllers.Contract;
using backend.Helpers;
using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Index.Strtree;

namespace backend.Controllers;

[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase, IAuthController
{
    private const string RefreshTokenCookieName = "refresh_token";
    
    private readonly IAuthService _authService = authService;
    
    [HttpPost("login")]
    public async Task<GenericResponse<string>> Login([FromBody] LoginRequest request)
    {
        try
        {
            var srv = await _authService.Login(request);
            
            SetCookie(RefreshTokenCookieName, srv.RefreshToken, DateTime.Now.AddDays(30));
            
            return ManageResponse.Create(srv.AccessToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("refresh")]
    public async Task<GenericResponse<string>> Refresh()
    {
        try
        {
            var refreshToken = Request.Cookies[RefreshTokenCookieName];
            if (string.IsNullOrEmpty(refreshToken)) throw new UnauthorizedAccessException("not allowed to refresh");
            
            var srv = await _authService.Refresh(refreshToken);
            
            SetCookie(RefreshTokenCookieName, srv.RefreshToken, DateTime.Now.AddDays(30));

            return ManageResponse.Create(srv.AccessToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("logout")]
    public async Task<GenericResponse<bool>> Logout()
    {
        try
        {
            var refreshToken = Request.Cookies[RefreshTokenCookieName];
            if (string.IsNullOrEmpty(refreshToken)) throw new UnauthorizedAccessException("not allowed for logout");
            
            await _authService.Logout(refreshToken);
            Response.Cookies.Delete(RefreshTokenCookieName);
            
            return ManageResponse.Create(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void SetCookie(string name, string value, DateTime expires)
    {
        Response.Cookies.Append(name, value, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = expires,
            Path = "/",
        });
    }
}