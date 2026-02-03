
using backend.Kazemaru.Domain.Entities;

namespace backend.Repositories.Contract
{
  public interface IAppRepository
  {
    List<Tag> GetTags();
    List<ProjectsStatus> GetProjectStatuses();
    List<TasksStatus> GetTaskStatuses();
  }
}
