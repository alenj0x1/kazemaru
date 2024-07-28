using backend.Entity;
using backend.Models.Request.Project;
using backend.Models.Request.Task;

namespace backend.Repositories.Contract
{
  public interface ITaskRepository
  {
    Task<Entity.Task> CreateTask(TaskCreateRequestModel model);
    Entity.Task? GetTask(Guid taskId);
    Entity.Task? GetTask(string taskName);
    List<Entity.Task> GetTasks(Guid projectId);
    List<Entity.Task> GetTasks();
    Task<Entity.Task?> UpdateTask(TaskUpdateRequestModel model);
    Task<bool> DeleteTask(Guid taskId);

    // Status
    Task<Taskstatus> CreateTaskStatus(TaskStatusCreateRequest model);
    Taskstatus? GetTaskStatus(int taskStatusId);
    Taskstatus? GetTaskStatus(string taskStatusName);
    Task<Taskstatus?> UpdateTaskStatus(TaskStatusUpdateRequest model);
    Task<bool> DeleteTaskStatus(int taskStatusId);
  }
}
