using backend.Kazemaru.Application.Models.Dtos;
using backend.Kazemaru.Application.Models.Responses;

namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IAppService
{
    GenericResponse<AppInfoDto> Info();
}