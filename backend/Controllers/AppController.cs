using backend.DTO;
using backend.Controllers.Contract;
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
        public GenericResponse<AppInfoDTO> Info()
        {
            try
            {
                return _srvApp.Info();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}