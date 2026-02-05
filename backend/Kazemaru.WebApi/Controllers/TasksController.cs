using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Requests.Task;
using Kazemaru.Application.Models.Requests.Task.Status;
using Kazemaru.Application.Models.Responses;
using Kazemaru.WebApi.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kazemaru.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(ITaskService taskService) : ControllerBase
{
    private readonly ITaskService _srvTask = taskService;

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpPost]
    public async Task<GenericResponse<TaskDto>> CreateTask([FromBody] TaskCreateRequestModel model)
    {
        try
        {
            return await _srvTask.Create(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpGet("{taskId:guid}")]
    public GenericResponse<TaskDto?> GetTask(Guid taskId)
    {
        try
        {
            return _srvTask.Get(taskId);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpGet]
    public GenericResponse<List<TaskDto>> GetTasks()
    {
        try
        {
            return _srvTask.Get();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpPut("{taskId:guid}")]
    public async Task<GenericResponse<TaskDto>> UpdateTask(Guid taskId, [FromBody] TaskUpdateRequestModel model)
    {
        try
        {
            return await _srvTask.Update(taskId, model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpDelete("{taskId:guid}")]
    public async Task<GenericResponse<TaskDto>> DeleteTask(Guid taskId)
    {
        try
        {
            return await _srvTask.Delete(taskId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpPost("status")]
    public async Task<GenericResponse<TaskStatusDto>> CreateTaskStatus([FromBody] TaskStatusCreateRequest model)
    {
        try
        {
            return await _srvTask.CreateStatus(model);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpPut("status/{taskStatusId:int}")]
    public async Task<GenericResponse<TaskStatusDto>> UpdateTaskStatus(int taskStatusId,
        [FromBody] TaskStatusUpdateRequest model)
    {
        try
        {
            return await _srvTask.UpdateStatus(taskStatusId, model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [Tags(OpenApiTagsConstants.Tasks, OpenApiTagsConstants.Authorization)]
    [HttpDelete("status/{taskStatusId:int}")]
    public async Task<GenericResponse<bool>> DeleteTaskStatus(int taskStatusId)
    {
        try
        {
            return await _srvTask.DeleteStatus(taskStatusId);
        }
        catch (Exception)
        {
            throw;
        }
    }
}