using Kazemaru.Domain.Entities;
using Task = Kazemaru.Domain.Entities.Task;

namespace Kazemaru.Domain.Interfaces.Persistence.Postgres.Repositories;

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