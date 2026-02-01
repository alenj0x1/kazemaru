using System.Security.Claims;
using backend.DTO;
using backend.Kazemaru.Application.Models.Responses;

namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDTO?> FirstUser();
    GenericResponse<UserDTO> Me(Claim userId);
}