using backend.DTO;
using backend.Entity;

namespace backend.Repositories.Contract
{
  public interface IAppRepository
  {
    List<Tag> GetTags();
    List<Projectstatus> GetProjectStatuses();
    List<Taskstatus> GetTaskStatuses();
  }
}
