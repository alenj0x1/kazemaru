using backend.Entity;
using backend.Models.Request.Task.Status;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class TaskRepository(KazemarudbContext db) : ITaskRepository
  {
    private readonly KazemarudbContext _db = db;

    public async Task<Entity.Task> CreateTask(Entity.Task task)
    {
      try
      {
        await _db.Tasks.AddAsync(task);
        await _db.SaveChangesAsync();

        return task;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Entity.Task? GetTask(Guid taskId)
    {
      try
      {
        return _db.Tasks.FirstOrDefault(tk => tk.Taskid == taskId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Entity.Task? GetTask(string taskName)
    {
      try
      {
        return _db.Tasks.FirstOrDefault(tk => tk.Name == taskName);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Entity.Task> GetTasks(Guid projectId)
    {
      try
      {
        return [.. _db.Tasks.Where(tk => tk.Projectid == projectId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Entity.Task> GetTasks()
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

    public async Task<Entity.Task?> UpdateTask(Entity.Task task)
    {
      try
      {
        _db.Tasks.Update(task);
        await _db.SaveChangesAsync();
        
        return task;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteTask(Entity.Task task)
    {
      try
      {
        _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();
        
        return false;
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    public async Task<Taskstatus> CreateTaskStatus(Taskstatus taskStatus)
    {
      try
      {
        _db.Taskstatuses.Add(taskStatus);
        await _db.SaveChangesAsync();
        
        return taskStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Taskstatus? GetTaskStatus(int taskStatusId)
    {
      try
      {
        return _db.Taskstatuses.FirstOrDefault(tks => tks.Taskstatusid == taskStatusId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Taskstatus? GetTaskStatus(string taskStatusName)
    {
      try
      {
        return _db.Taskstatuses.FirstOrDefault(tks => tks.Name == taskStatusName);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Taskstatus?> UpdateTaskStatus(Taskstatus taskStatus)
    {
      try
      {
        _db.Taskstatuses.Update(taskStatus);
        await _db.SaveChangesAsync();
        
        return taskStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteTaskStatus(Taskstatus taskStatus)
    {
      try
      {
        _db.Taskstatuses.Remove(taskStatus);
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
