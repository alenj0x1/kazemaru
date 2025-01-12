using backend.DTO;
using backend.Models;
using backend.Models.Request.Task;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Contract
{
  public interface IAppController
  {
    GenericResponse<AppInfoDTO> Info();
  }
}
