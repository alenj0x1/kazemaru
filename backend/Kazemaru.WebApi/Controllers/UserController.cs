using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kazemaru.WebApi.Controllers;

[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public GenericResponse<UserDto> Me()
    {
        try
        {
            var userClaim = User.FindFirst("UserId") ?? throw new UnauthorizedAccessException("Missing User Id Claim");
            return _userService.Me(userClaim);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}