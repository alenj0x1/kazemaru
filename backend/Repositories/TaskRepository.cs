using backend.Entity;
using backend.Models.Request.Task;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class TaskRepository : ITaskRepository
  {
    public async Task<Entity.Task> CreateTask(KazemarudbContext db, TaskCreateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Entity.Task newTask = new()
        {
          Name = model.Name,
          Projectid = model.Projectid,
          Description = model.Description,
          Status = model.Status,
        };

        await db.Tasks.AddAsync(newTask);
        await db.SaveChangesAsync();

        await tx.CommitAsync();

        return newTask;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Entity.Task? GetTask(KazemarudbContext db, Guid taskId)
    {
      try
      {
        return db.Tasks.Where(task => task.Taskid == taskId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Entity.Task? GetTask(KazemarudbContext db, string taskName)
    {
      try
      {
        return db.Tasks.Where(task => task.Name == taskName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Entity.Task? GetTask(KazemarudbContext db, Guid taskId, Guid projectId)
    {
      try
      {
        return db.Tasks.Where(task => task.Taskid == taskId && task.Projectid == projectId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Entity.Task> GetTasks(KazemarudbContext db)
    {
      try
      {
        return [.. db.Tasks];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Entity.Task> GetTasks(KazemarudbContext db, Guid projectId)
    {
      try
      {
        return [.. db.Tasks.Where(task => task.Projectid == projectId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Entity.Task> GetTasks(KazemarudbContext db, string taskName)
    {
      try
      {
        return [.. db.Tasks.Where(task => task.Name == taskName)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Entity.Task?> UpdateTask(KazemarudbContext db, TaskUpdateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Entity.Task? updTask = GetTask(db, model.TaskId);

        if (updTask is not null)
        {
          updTask.Name = model.Name ?? updTask.Name;
          updTask.Description = model.Description ?? updTask.Description;
          updTask.Status = model.Status ?? updTask.Status;
          updTask.Projectid = model.Projectid ?? updTask.Projectid;

          db.Tasks.Update(updTask);
          await db.SaveChangesAsync();
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

    public async Task<bool> DeleteTask(KazemarudbContext db, Guid taskId)
    {
      using var tx = db.Database.BeginTransaction();

      try
      {
        Entity.Task? delTask = GetTask(db, taskId);

        if (delTask is not null)
        {
          db.Tasks.Remove(delTask);
          await db.SaveChangesAsync();
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

    public Taskstatus? GetTaskStatus(KazemarudbContext db, int statusId)
    {
      try
      {
        return db.Taskstatuses.Where(taskStat => taskStat.Statusid == statusId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
