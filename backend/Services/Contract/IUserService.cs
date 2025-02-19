using System.Security.Claims;
using backend.DTO;
using backend.Models;

namespace backend.Services.Contract;

public interface IUserService
{
    Task<UserDTO?> FirstUser();
    GenericResponse<UserDTO> Me(Claim userId);
}