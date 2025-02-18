using backend.Entity;

namespace backend.Repositories.Contract
{
  public interface ITaskRepository
  {
    Entity.Task? Get(Guid taskId);
    Entity.Task? Get(string name);
    List<Entity.Task> GetByProject(Guid projectId);
    List<Entity.Task> Get();

    // Status
    Task<TasksStatus> CreateStatus(TasksStatus taskStatus);
    TasksStatus? GetStatus(int taskStatusId);
    TasksStatus? GetStatus(string name);
    Task<TasksStatus?> UpdateStatus(TasksStatus taskStatus);
    Task<bool> DeleteStatus(TasksStatus taskStatus);
  }
}
