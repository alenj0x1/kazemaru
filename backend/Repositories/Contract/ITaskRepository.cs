using backend.Entity;
using backend.Entity.Postgres;
using Task = backend.Entity.Postgres.Task;

namespace backend.Repositories.Contract
{
  public interface ITaskRepository
  {
    Task? Get(Guid taskId);
    Task? Get(string name);
    List<Task> GetByProject(Guid projectId);
    List<Task> Get();

    // Status
    Task<TasksStatus> CreateStatus(TasksStatus taskStatus);
    TasksStatus? GetStatus(int taskStatusId);
    TasksStatus? GetStatus(string name);
    Task<TasksStatus?> UpdateStatus(TasksStatus taskStatus);
    Task<bool> DeleteStatus(TasksStatus taskStatus);
  }
}
