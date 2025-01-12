using backend.DTO;
using backend.Models;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Contract
{
  public interface ITasksController
  {
    Task<GenericResponse<TaskDTO>> CreateTask([FromBody] TaskCreateRequestModel model);
    GenericResponse<TaskDTO?> GetTask(Guid taskId);
    GenericResponse<List<TaskDTO>> GetTasks();
    Task<GenericResponse<TaskDTO>> UpdateTask(Guid taskId, [FromBody] TaskUpdateRequestModel model);
    Task<GenericResponse<bool>> DeleteTask(Guid taskId);

    // Status
    Task<GenericResponse<TaskStatusDTO>> CreateTaskStatus([FromBody] TaskStatusCreateRequest model);
    Task<GenericResponse<TaskStatusDTO>> UpdateTaskStatus(int taskStatusId, [FromBody] TaskStatusUpdateRequest model);
    Task<GenericResponse<bool>> DeleteTaskStatus(int taskStatusId);
  }
}
