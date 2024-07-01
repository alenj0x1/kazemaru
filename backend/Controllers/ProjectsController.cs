using backend.DTO;
using backend.Interfaces;
using backend.Models;
using backend.Models.Request.Note;
using backend.Models.Request.Project;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectsController(IProjectService projServ) : ControllerBase, IProjectController
  {
    private readonly IProjectService _projServ = projServ;

    // Project
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] ProjectCreateRequestModel model)
    {
      GenericResponse<ProjectDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.IsSuccess = true;
        rsp.Data = await _projServ.CreateProject(model);
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
        rsp.Data = _projServ.GetProject(projectId);
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    [HttpGet("byName/{projectName}")]
    public IActionResult GetProject(string projectName)
    {
      GenericResponse<ProjectDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.IsSuccess = true;
        rsp.Data = _projServ.GetProject(projectName);
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = false;
        return BadRequest(rsp);
      }
    }

    [HttpGet("all")]
    public IActionResult GetProjects()
    {
      GenericResponse<List<ProjectDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.IsSuccess = true;
        rsp.Data = _projServ.GetProjects();
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
        rsp.Data = await _projServ.UpdateProject(model);
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
        bool delProj = await _projServ.DeleteProject(projectId);

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

    // Project status
    [HttpPost("status/")]
    public async Task<IActionResult> CreateProjectStatus([FromBody] ProjectStatusCreateRequestModel model)
    {
      GenericResponse<ProjectStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _projServ.CreateProjectStatus(model);
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

    [HttpGet("status/{statusName}")]
    public IActionResult GetProjectStatus(string statusName)
    {
      GenericResponse<ProjectStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _projServ.GetProjectStatus(statusName);
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

    [HttpGet("status/all")]
    public IActionResult GetAllProjectStatus()
    {
      GenericResponse<List<ProjectStatusDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _projServ.GetAllProjectStatus();
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

    [HttpPut("status/")]
    public async Task<IActionResult> UpdateProjectStatus([FromBody] ProjectStatusUpdateRequestModel model)
    {
      GenericResponse<ProjectStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _projServ.UpdateProjectStatus(model);
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

    [HttpDelete("status/{statusName}")]
    public async Task<IActionResult> DeleteProjectStatus(string statusName)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        bool delProjectStatus = await _projServ.DeleteProjectStatus(statusName);

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

    // Project tag
    [HttpPost("tag")]
    public async Task<IActionResult> CreateProjectTag([FromBody] ProjectTagCreateRequestModel model)
    {
      GenericResponse<ProjectTagDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _projServ.CreateProjectTag(model);
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

    [HttpGet("tag/{projectTagId}")]
    public IActionResult GetProjectTag(Guid projectTagId)
    {
      GenericResponse<ProjectTagDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _projServ.GetProjectTag(projectTagId);
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

    [HttpGet("tag/all")]
    public IActionResult GetProjectTags()
    {
      GenericResponse<List<ProjectTagDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _projServ.GetProjectTags();
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

    [HttpPut("tag")]
    public async Task<IActionResult> UpdateProjectTag([FromBody] ProjectTagUpdateRequestModel model)
    {
      GenericResponse<ProjectTagDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _projServ.UpdateProjectTag(model);
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

    [HttpDelete("tag/{projectTagId}")]
    public async Task<IActionResult> DeleteProjectTag(Guid projectTagId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _projServ.DeleteProjectTag(projectTagId);
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
