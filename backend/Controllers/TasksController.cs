using backend.DTO;
using backend.Interfaces;
using backend.Models;
using backend.Models.Request.Task;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController(ITaskService taskService) : ControllerBase, ITasksController
  {
    private readonly ITaskService _srvTask = taskService;

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequestModel model)
    {
      GenericResponse<TaskDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvTask.CreateTask(model);
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
        rsp.Data = _srvTask.GetTask(taskId);
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

    [HttpGet]
    public IActionResult GetTasks()
    {
      GenericResponse<List<TaskDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _srvTask.GetTasks();
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
        rsp.Data = await _srvTask.UpdateTask(model);
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
        rsp.Data = await _srvTask.DeleteTask(taskId);
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

    [HttpPost("status")]
    public async Task<IActionResult> CreateTaskStatus([FromBody] TaskStatusCreateRequest model)
    {
      GenericResponse<TaskStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvTask.CreateTaskStatus(model);
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
    public async Task<IActionResult> UpdateTaskStatus([FromBody] TaskStatusUpdateRequest model)
    {
      GenericResponse<TaskStatusDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvTask.UpdateTaskStatus(model);
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

    [HttpDelete("status/{taskStatusId}")]
    public async Task<IActionResult> DeleteTaskStatus(int taskStatusId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvTask.DeleteTaskStatus(taskStatusId);
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
