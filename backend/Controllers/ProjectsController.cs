using backend.DTO;
using backend.Interfaces;
using backend.Models;
using backend.Models.Request.Project;
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
    public async Task<IActionResult> CreateProject([FromBody] ProjectCreateRequestModel model)
    {
      GenericResponse<ProjectDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.IsSuccess = true;
        rsp.Data = await _srvProj.CreateProject(model); 
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    [HttpGet("{projectId}")]
    public IActionResult GetProject(Guid projectId)
    {
      GenericResponse<ProjectDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.IsSuccess = true;
        rsp.Data = _srvProj.GetProject(projectId);
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    [HttpGet]
    public IActionResult GetProjects()
    {
      GenericResponse<List<ProjectDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.IsSuccess = true;
        rsp.Data = _srvProj.GetProjects();
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.IsSuccess = false;
        rsp.Message = ex.Message;
        return BadRequest(rsp);
      }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject([FromBody] ProjectUpdateRequestModel model)
    {
      GenericResponse<ProjectDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvProj.UpdateProject(model);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return Ok(rsp);
      }
    }

    [HttpDelete("{projectId}")]
    public async Task<IActionResult> DeleteProject(Guid projectId)
    {
      GenericResponse<ProjectDTO> rsp = new();

      try
      {
        bool delProj = await _srvProj.DeleteProject(projectId);

        if (!delProj)
        {
          rsp.Message = "without changes.";
          rsp.IsSuccess = delProj;
          return BadRequest(rsp);
        }

        rsp.Message = "OK";
        rsp.IsSuccess = delProj;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    // Status
    [HttpPost("status")]
    public async Task<IActionResult> CreateProjectStatus([FromBody] ProjectStatusCreateRequestModel model)
    {
      GenericResponse<ProjectStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvProj.CreateProjectStatus(model);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    [HttpPut("status")]
    public async Task<IActionResult> UpdateProjectStatus([FromBody] ProjectStatusUpdateRequestModel model)
    {
      GenericResponse<ProjectStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvProj.UpdateProjectStatus(model);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    [HttpDelete("status/{projectStatusId}")]
    public async Task<IActionResult> DeleteProjectStatus(int projectStatusId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        bool delProjectStatus = await _srvProj.DeleteProjectStatus(projectStatusId);

        if (!delProjectStatus)
        {
          rsp.Message = "OK";
          rsp.Data = delProjectStatus;
          rsp.IsSuccess = false;
          return BadRequest(rsp);
        };

        rsp.Message = "OK";
        rsp.Data = delProjectStatus;
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }
  }
}
