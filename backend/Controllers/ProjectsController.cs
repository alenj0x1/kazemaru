using backend.Controllers.Contract;
using backend.DTO;
using backend.Models;
using backend.Models.Request.Project;
using backend.Models.Request.Project.Status;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectsController(IProjectService projectService) : ControllerBase, IProjectsController
  {
    private readonly IProjectService _srvProj = projectService;

    [HttpPost]
    public async Task<GenericResponse<ProjectDTO>> CreateProject([FromBody] ProjectCreateRequestModel model)
    {
      try
      {
        return await _srvProj.CreateProject(model);
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpGet("{projectId:guid}")]
    public GenericResponse<ProjectDTO?> GetProject(Guid projectId)
    {
      try
      {
        return _srvProj.GetProject(projectId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpGet]
    public GenericResponse<List<ProjectDTO>> GetProjects()
    {
      try
      {
        return _srvProj.GetProjects();
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpPut("{projectId:guid}")]
    public async Task<GenericResponse<ProjectDTO>> UpdateProject(Guid projectId, [FromBody] ProjectUpdateRequestModel model)
    {
      try
      {
        return await _srvProj.UpdateProject(projectId, model);
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpDelete("{projectId:guid}")]
    public async Task<GenericResponse<bool>> DeleteProject(Guid projectId)
    {
      try
      {
        return await _srvProj.DeleteProject(projectId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    [HttpPost("status")]
    public async Task<GenericResponse<ProjectStatusDTO>> CreateProjectStatus([FromBody] ProjectStatusCreateRequestModel model)
    {
      try
      {
        return await _srvProj.CreateProjectStatus(model);
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpPut("status/{projectStatusId:int}")]
    public async Task<GenericResponse<ProjectStatusDTO>> UpdateProjectStatus(int projectStatusId, [FromBody] ProjectStatusUpdateRequestModel model)
    {
      try
      {
        return await _srvProj.UpdateProjectStatus(projectStatusId, model);
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpDelete("status/{projectStatusId:int}")]
    public async Task<GenericResponse<bool>> DeleteProjectStatus(int projectStatusId)
    {
      try
      {
        return await _srvProj.DeleteProjectStatus(projectStatusId);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
