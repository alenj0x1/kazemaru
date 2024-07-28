using backend.Entity;
using backend.Models.Request.Project;
using backend.Models.Request.Task;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class TaskRepository(KazemarudbContext db) : ITaskRepository
  {
    private readonly KazemarudbContext _db = db;

    public async Task<Entity.Task> CreateTask(TaskCreateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Entity.Task crtTask = new()
        {
          Name = model.Name,
          Projectid = model.Projectid,
          Description = model.Description,
          Statusid = model.Status,
        };

        await _db.Tasks.AddAsync(crtTask);
        await _db.SaveChangesAsync();

        await tx.CommitAsync();

        return crtTask;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Entity.Task? GetTask(Guid taskId)
    {
      try
      {
        return _db.Tasks.Where(tk => tk.Taskid == taskId).FirstOrDefault();
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
        return _db.Tasks.Where(tk => tk.Name == taskName).FirstOrDefault();
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

    public async Task<Entity.Task?> UpdateTask(TaskUpdateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Entity.Task? updTask = GetTask(model.TaskId);

        if (updTask is not null)
        {
          updTask.Name = model.Name ?? updTask.Name;
          updTask.Description = model.Description ?? updTask.Description;
          updTask.Statusid = model.Status ?? updTask.Statusid;
          updTask.Projectid = model.Projectid ?? updTask.Projectid;

          _db.Tasks.Update(updTask);
          await _db.SaveChangesAsync();
        }

        await tx.CommitAsync();
        return updTask;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteTask(Guid taskId)
    {
      using var tx = _db.Database.BeginTransaction();

      try
      {
        Entity.Task? delTask = GetTask(taskId);

        if (delTask is not null)
        {
          _db.Tasks.Remove(delTask);
          await _db.SaveChangesAsync();
          await tx.CommitAsync();

          return true;
        }

        return false;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    // Status
    public async Task<Taskstatus> CreateTaskStatus(TaskStatusCreateRequest model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Taskstatus crtTaskStatus = new()
        {
          Name = model.Name,
        };

        await _db.Taskstatuses.AddAsync(crtTaskStatus);
        await _db.SaveChangesAsync();

        await tx.CommitAsync();
        return crtTaskStatus;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Taskstatus? GetTaskStatus(int taskStatusId)
    {
      try
      {
        return _db.Taskstatuses.Where(tks => tks.Taskstatusid == taskStatusId).FirstOrDefault();
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
        return _db.Taskstatuses.Where(tks => tks.Name == taskStatusName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Taskstatus?> UpdateTaskStatus(TaskStatusUpdateRequest model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Taskstatus? gtTaskStatus = GetTaskStatus(model.TaskStatusId);

        if (gtTaskStatus is not null)
        {
          gtTaskStatus.Name = model.Name ?? gtTaskStatus.Name;

          _db.Taskstatuses.Update(gtTaskStatus);
          await _db.SaveChangesAsync();
        }

        await tx.CommitAsync();

        return gtTaskStatus;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteTaskStatus(int taskStatusId)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Taskstatus? gtTaskStatus = GetTaskStatus(taskStatusId);

        if (gtTaskStatus is not null)
        {
          _db.Taskstatuses.Remove(gtTaskStatus);
          await _db.SaveChangesAsync();
          await tx.CommitAsync();
          return true;
        }

        await tx.RollbackAsync();

        return false;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        return false;
      }
    }
  }
}
