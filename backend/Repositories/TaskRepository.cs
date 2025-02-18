using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class TaskRepository(KazemaruDbContext db) : ITaskRepository
  {
    private readonly KazemaruDbContext _db = db;

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
        return _db.Tasks.FirstOrDefault(tk => tk.TaskId == taskId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Entity.Task? GetTask(string name)
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

    public List<Entity.Task> GetTasks(Guid projectId)
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
    public async Task<TasksStatus> CreateTaskStatus(TasksStatus taskStatus)
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

    public TasksStatus? GetTaskStatus(int taskStatusId)
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

    public TasksStatus? GetTaskStatus(string name)
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

    public async Task<TasksStatus?> UpdateTaskStatus(TasksStatus taskStatus)
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

    public async Task<bool> DeleteTaskStatus(TasksStatus taskStatus)
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
