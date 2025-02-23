using backend.Entity;
using backend.Entity.Postgres;

namespace backend.Repositories.Contract
{
  public interface IAppRepository
  {
    List<Tag> GetTags();
    List<ProjectsStatus> GetProjectStatuses();
    List<TasksStatus> GetTaskStatuses();
  }
}
