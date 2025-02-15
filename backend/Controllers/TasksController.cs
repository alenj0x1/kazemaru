using backend.DTO;
using backend.Controllers.Contract;
using backend.Models;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;
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
        public async Task<GenericResponse<TaskDTO>> CreateTask([FromBody] TaskCreateRequestModel model)
        {
            try
            {
                return await _srvTask.CreateTask(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{taskId:guid}")]
        public GenericResponse<TaskDTO?> GetTask(Guid taskId)
        {
            try
            {
                return _srvTask.GetTask(taskId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public GenericResponse<List<TaskDTO>> GetTasks()
        {
            try
            {
                return _srvTask.GetTasks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{taskId:guid}")]
        public async Task<GenericResponse<TaskDTO>> UpdateTask(Guid taskId, [FromBody] TaskUpdateRequestModel model)
        {
            try
            {
                return await _srvTask.UpdateTask(taskId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{taskId:guid}")]
        public async Task<GenericResponse<bool>> DeleteTask(Guid taskId)
        {
            try
            {
                return await _srvTask.DeleteTask(taskId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("status")]
        public async Task<GenericResponse<TaskStatusDTO>> CreateTaskStatus([FromBody] TaskStatusCreateRequest model)
        {
            try
            {
                return await _srvTask.CreateTaskStatus(model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut("status/{taskStatusId:int}")]
        public async Task<GenericResponse<TaskStatusDTO>> UpdateTaskStatus(int taskStatusId,
            [FromBody] TaskStatusUpdateRequest model)
        {
            try
            {
                return await _srvTask.UpdateTaskStatus(taskStatusId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("status/{taskStatusId:int}")]
        public async Task<GenericResponse<bool>> DeleteTaskStatus(int taskStatusId)
        {
            try
            {
                return await _srvTask.DeleteTaskStatus(taskStatusId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}