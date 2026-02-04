using Kazemaru.Domain.Entities;

namespace Kazemaru.Domain.Interfaces.Persistence.Postgres.Repositories;

public interface IAppRepository
{
    List<Tag> GetTags();
    List<ProjectsStatus> GetProjectStatuses();
    List<TasksStatus> GetTaskStatuses();
}