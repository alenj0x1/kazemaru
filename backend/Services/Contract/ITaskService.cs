using backend.DTO;
using backend.Entity;
using backend.Models.Request.Project;
using backend.Models.Request.Task;

namespace backend.Services.Contract
{
  public interface ITaskService
  {
    Task<TaskDTO> CreateTask(TaskCreateRequestModel model);
    TaskDTO? GetTask(Guid taskId);
    List<TaskDTO> GetTasks();
    Task<TaskDTO?> UpdateTask(TaskUpdateRequestModel model);
    Task<bool> DeleteTask(Guid taskId);

    // Status
    Task<TaskStatusDTO> CreateTaskStatus(TaskStatusCreateRequest model);
    TaskStatusDTO GetTaskStatus(int taskStatusId);
    Task<TaskStatusDTO> UpdateTaskStatus(TaskStatusUpdateRequest model);
    Task<bool> DeleteTaskStatus(int taskStatusId);
  }
}
