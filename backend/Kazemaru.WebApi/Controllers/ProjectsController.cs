using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Requests.Project;
using Kazemaru.Application.Models.Requests.Project.Status;
using Kazemaru.Application.Models.Responses;
using Kazemaru.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kazemaru.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _srvProj = projectService;

    [Authorize]
    [HttpPost]
    public async Task<GenericResponse<ProjectDto>> CreateProject([FromBody] ProjectCreateRequestModel model)
    {
        try
        {
            var userId = User.FindFirst("UserId") ??
                         throw new UnauthorizedAccessException(ResponseConstants.UserIdentityNotFound);
            return await _srvProj.Create(model, userId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpGet("{projectId:guid}")]
    public GenericResponse<ProjectDto?> GetProject(Guid projectId)
    {
        try
        {
            return _srvProj.Get(projectId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpGet]
    public GenericResponse<List<ProjectDto>> GetProjects()
    {
        try
        {
            return _srvProj.Get();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpPut("{projectId:guid}")]
    public async Task<GenericResponse<ProjectDto>> UpdateProject(Guid projectId,
        [FromBody] ProjectUpdateRequestModel model)
    {
        try
        {
            return await _srvProj.Update(projectId, model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpDelete("{projectId:guid}")]
    public async Task<GenericResponse<ProjectDto>> DeleteProject(Guid projectId)
    {
        try
        {
            return await _srvProj.Delete(projectId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // Status
    [Authorize]
    [HttpPost("status")]
    public async Task<GenericResponse<ProjectStatusDto>> CreateProjectStatus(
        [FromBody] ProjectStatusCreateRequestModel model)
    {
        try
        {
            return await _srvProj.CreateStatus(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpPut("status/{projectStatusId:int}")]
    public async Task<GenericResponse<ProjectStatusDto>> UpdateProjectStatus(int projectStatusId,
        [FromBody] ProjectStatusUpdateRequestModel model)
    {
        try
        {
            return await _srvProj.UpdateStatus(projectStatusId, model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpDelete("status/{projectStatusId:int}")]
    public async Task<GenericResponse<bool>> DeleteProjectStatus(int projectStatusId)
    {
        try
        {
            return await _srvProj.DeleteStatus(projectStatusId);
        }
        catch (Exception)
        {
            throw;
        }
    }
}