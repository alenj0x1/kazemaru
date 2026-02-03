using System.Security.Claims;
using backend.Kazemaru.Application.Models.Dtos;
using backend.Kazemaru.Application.Models.Responses;

namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDto?> FirstUser();
    GenericResponse<UserDto> Me(Claim userId);
}