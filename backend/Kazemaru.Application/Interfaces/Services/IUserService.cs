using System.Security.Claims;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Responses;

namespace Kazemaru.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDto?> FirstUser();
    GenericResponse<UserDto> Me(Claim userId);
}