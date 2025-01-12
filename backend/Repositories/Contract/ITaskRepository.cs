using backend.Entity;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;

namespace backend.Repositories.Contract
{
  public interface ITaskRepository
  {
    Task<Entity.Task> CreateTask(Entity.Task task);
    Entity.Task? GetTask(Guid taskId);
    Entity.Task? GetTask(string taskName);
    List<Entity.Task> GetTasks(Guid projectId);
    List<Entity.Task> GetTasks();
    Task<Entity.Task?> UpdateTask(Entity.Task task);
    Task<bool> DeleteTask(Entity.Task task);

    // Status
    Task<Taskstatus> CreateTaskStatus(Taskstatus taskStatus);
    Taskstatus? GetTaskStatus(int taskStatusId);
    Taskstatus? GetTaskStatus(string taskStatusName);
    Task<Taskstatus?> UpdateTaskStatus(Taskstatus taskStatus);
    Task<bool> DeleteTaskStatus(Taskstatus taskStatus);
  }
}
