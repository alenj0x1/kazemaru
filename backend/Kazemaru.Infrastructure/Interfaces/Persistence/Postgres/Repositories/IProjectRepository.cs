using backend.Kazemaru.Domain.Entities;

namespace backend.Repositories.Contract
{
  public interface IProjectRepository
  {
    Guid? FindIfExists(Guid projectId);
    Project? Get(Guid projectId);
    Project? Get(string name);
    List<Project> Get();

    // Status
    Task<ProjectsStatus> CreateStatus(ProjectsStatus projectStatus);
    int? FindIfExistsStatus(int projectStatusId);
    ProjectsStatus? GetStatus(int projectStatusId);
    ProjectsStatus? GetStatus(string projectStatusName);
    Task<ProjectsStatus?> UpdateStatus(ProjectsStatus projectStatus);
    Task<bool> DeleteStatus(ProjectsStatus projectStatus);
  }
}
