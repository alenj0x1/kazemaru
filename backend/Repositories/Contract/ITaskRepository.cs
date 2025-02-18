using backend.Entity;

namespace backend.Repositories.Contract
{
  public interface ITaskRepository
  {
    Task<Entity.Task> CreateTask(Entity.Task task);
    Entity.Task? GetTask(Guid taskId);
    Entity.Task? GetTask(string name);
    List<Entity.Task> GetTasks(Guid projectId);
    List<Entity.Task> GetTasks();
    Task<Entity.Task?> UpdateTask(Entity.Task task);
    Task<bool> DeleteTask(Entity.Task task);

    // Status
    Task<TasksStatus> CreateTaskStatus(TasksStatus taskStatus);
    TasksStatus? GetTaskStatus(int taskStatusId);
    TasksStatus? GetTaskStatus(string name);
    Task<TasksStatus?> UpdateTaskStatus(TasksStatus taskStatus);
    Task<bool> DeleteTaskStatus(TasksStatus taskStatus);
  }
}
