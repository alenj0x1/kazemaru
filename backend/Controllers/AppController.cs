using backend.DTO;
using backend.Interfaces;
using backend.Models;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AppController(IAppService appService) : ControllerBase, IAppController
  {
    private readonly IAppService _srvApp = appService;

    [HttpGet("info")]
    public IActionResult Info()
    {
      GenericResponse<AppInfoDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _srvApp.Info();
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = true;
        return BadRequest(rsp);
      }
    }
  }
}
