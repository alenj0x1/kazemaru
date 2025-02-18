using backend.DTO;
using backend.Controllers.Contract;
using backend.Models;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;
using backend.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITaskService taskService) : ControllerBase, ITasksController
    {
        private readonly ITaskService _srvTask = taskService;

        [Authorize]
        [HttpPost]
        public async Task<GenericResponse<TaskDTO>> CreateTask([FromBody] TaskCreateRequestModel model)
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
        [HttpGet("{taskId:guid}")]
        public GenericResponse<TaskDTO?> GetTask(Guid taskId)
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
        [HttpGet]
        public GenericResponse<List<TaskDTO>> GetTasks()
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
        [HttpPut("{taskId:guid}")]
        public async Task<GenericResponse<TaskDTO>> UpdateTask(Guid taskId, [FromBody] TaskUpdateRequestModel model)
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
        [HttpDelete("{taskId:guid}")]
        public async Task<GenericResponse<TaskDTO>> DeleteTask(Guid taskId)
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
        [HttpPost("status")]
        public async Task<GenericResponse<TaskStatusDTO>> CreateTaskStatus([FromBody] TaskStatusCreateRequest model)
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
        [HttpPut("status/{taskStatusId:int}")]
        public async Task<GenericResponse<TaskStatusDTO>> UpdateTaskStatus(int taskStatusId,
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
}