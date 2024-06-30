using backend.DTO;
using backend.Interfaces;
using backend.Models;
using backend.Models.Request.Task;
using backend.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController(ITaskService taskServ) : ControllerBase, ITasksController
  {
    private readonly ITaskService _taskServ = taskServ;

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequestModel model)
    {
      GenericResponse<TaskDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _taskServ.CreateTask(model);
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

    [HttpGet("{taskId}")]
    public IActionResult GetTask(Guid taskId)
    {
      GenericResponse<TaskDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _taskServ.GetTask(taskId);
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

    [HttpGet("byName/{taskName}")]
    public IActionResult GetTask(string taskName)
    {
      GenericResponse<TaskDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _taskServ.GetTask(taskName);
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

    [HttpGet("all")]
    public IActionResult GetTasks()
    {
      GenericResponse<List<TaskDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _taskServ.GetTasks();
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

    [HttpGet("all/{taskName}")]
    public IActionResult GetTasks(string taskName)
    {
      GenericResponse<List<TaskDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _taskServ.GetTasks(taskName);
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

    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestModel model)
    {
      GenericResponse<TaskDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _taskServ.UpdateTask(model);
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

    [HttpDelete("{taskId}")]
    public async Task<IActionResult> DeleteTask(Guid taskId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _taskServ.DeleteTask(taskId);
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
