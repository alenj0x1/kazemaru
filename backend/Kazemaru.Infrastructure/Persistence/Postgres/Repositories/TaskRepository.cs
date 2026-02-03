using backend.Kazemaru.Infrastructure.Persistence.Postgres.Context;
using backend.Kazemaru.Domain.Entities;
using backend.Repositories.Contract;
using Task = backend.Kazemaru.Domain.Entities.Task;

namespace backend.Kazemaru.Infrastructure.Persistence.Postgres.Repositories
{
  public class TaskRepository(KazemaruDbContext db) : BaseRepository<Task>(db), ITaskRepository
  {
    private readonly KazemaruDbContext _db = db;

    public Task? Get(Guid taskId)
    {
      try
      {
        return _db.Tasks.FirstOrDefault(tk => tk.TaskId == taskId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Task? Get(string name)
    {
      try
      {
        return _db.Tasks.FirstOrDefault(tk => tk.Name == name);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Task> GetByProject(Guid projectId)
    {
      try
      {
        return [.. _db.Tasks.Where(tk => tk.ProjectId == projectId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Task> Get()
    {
      try
      {
        return [.. _db.Tasks];
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    public async Task<TasksStatus> CreateStatus(TasksStatus taskStatus)
    {
      try
      {
        _db.TasksStatuses.Add(taskStatus);
        await _db.SaveChangesAsync();
        
        return taskStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public TasksStatus? GetStatus(int taskStatusId)
    {
      try
      {
        return _db.TasksStatuses.FirstOrDefault(tks => tks.TaskStatusId == taskStatusId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public TasksStatus? GetStatus(string name)
    {
      try
      {
        return _db.TasksStatuses.FirstOrDefault(tks => tks.Name == name);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<TasksStatus?> UpdateStatus(TasksStatus taskStatus)
    {
      try
      {
        _db.TasksStatuses.Update(taskStatus);
        await _db.SaveChangesAsync();
        
        return taskStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteStatus(TasksStatus taskStatus)
    {
      try
      {
        _db.TasksStatuses.Remove(taskStatus);
        await _db.SaveChangesAsync();
        
        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
