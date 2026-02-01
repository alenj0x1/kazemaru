using backend.DTO;
using backend.Kazemaru.Application.Models.Responses;

namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IAppService
{
    GenericResponse<AppInfoDTO> Info();
}