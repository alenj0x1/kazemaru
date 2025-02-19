using backend.DTO;
using backend.Models;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public GenericResponse<UserDTO> Me()
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