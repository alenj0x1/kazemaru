using backend.Entity;
using backend.Models.Request.Task;

namespace backend.Repositories.Contract
{
  public interface ITaskRepository
  {
    Task<Entity.Task> CreateTask(KazemarudbContext db, TaskCreateRequestModel model);
    Entity.Task? GetTask(KazemarudbContext db, string taskName);
    Entity.Task? GetTask(KazemarudbContext db, Guid taskId);
    Entity.Task? GetTask(KazemarudbContext db, Guid taskId, Guid projectId);
    List<Entity.Task> GetTasks(KazemarudbContext db);
    List<Entity.Task> GetTasks(KazemarudbContext db, Guid projectId);
    List<Entity.Task> GetTasks(KazemarudbContext db, string taskName);
    Task<Entity.Task?> UpdateTask(KazemarudbContext db, TaskUpdateRequestModel model);
    Task<bool> DeleteTask(KazemarudbContext db, Guid taskId);

    Taskstatus? GetTaskStatus(KazemarudbContext db, int statusId);
  }
}
