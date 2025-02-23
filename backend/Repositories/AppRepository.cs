using backend.Entity;
using backend.Entity.Postgres;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class AppRepository(KazemaruDbContext db) : IAppRepository
  {
    private readonly KazemaruDbContext _db = db;

    public List<Tag> GetTags()
    {
      try
      {
        return [.. _db.Tags];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<ProjectsStatus> GetProjectStatuses()
    {
      try
      {
        return [.. _db.ProjectsStatuses];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<TasksStatus> GetTaskStatuses()
    {
      try
      {
        return [.. _db.TasksStatuses];
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
