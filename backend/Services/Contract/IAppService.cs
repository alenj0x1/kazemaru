using backend.DTO;
using backend.Models;

namespace backend.Services.Contract
{
    public interface IAppService
    {
        GenericResponse<AppInfoDTO> Info();
    }
}