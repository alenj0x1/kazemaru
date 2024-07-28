using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class AppRepository(KazemarudbContext db) : IAppRepository
  {
    private readonly KazemarudbContext _db = db;

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

    public List<Projectstatus> GetProjectStatuses()
    {
      try
      {
        return [.. _db.Projectstatuses];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Taskstatus> GetTaskStatuses()
    {
      try
      {
        return [.. _db.Taskstatuses];
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
