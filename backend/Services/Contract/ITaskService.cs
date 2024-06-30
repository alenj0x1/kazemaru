using backend.DTO;
using backend.Entity;
using backend.Models.Request.Task;

namespace backend.Services.Contract
{
  public interface ITaskService
  {
    Task<TaskDTO> CreateTask(TaskCreateRequestModel model);
    TaskDTO? GetTask(string taskName);
    TaskDTO? GetTask(Guid taskId);
    List<TaskDTO> GetTasks();
    List<TaskDTO> GetTasks(string taskName);
    Task<TaskDTO?> UpdateTask(TaskUpdateRequestModel model);
    Task<bool> DeleteTask(Guid taskId);
  }
}
