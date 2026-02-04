using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Responses;

namespace Kazemaru.Application.Interfaces.Services;

public interface IAppService
{
    GenericResponse<AppInfoDto> Info();
}