using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Responses;
using Kazemaru.WebApi.Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Kazemaru.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppController(IAppService appService) : ControllerBase
{
    private readonly IAppService _srvApp = appService;

    [HttpGet("info")]
    [Tags(OpenApiTagsConstants.App)]
    public GenericResponse<AppInfoDto> Info()
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