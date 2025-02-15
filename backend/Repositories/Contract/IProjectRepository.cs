using backend.Entity;
using backend.Models.Request.Project;

namespace backend.Repositories.Contract
{
  public interface IProjectRepository
  {
    Task<Project> CreateProject(Project project);
    Guid? FindIfExistsProject(Guid projectId);
    Project? GetProject(Guid projectId);
    Project? GetProject(string projectName);
    List<Project> GetProjects();
    Task<Project?> UpdateProject(Project project);
    Task<bool> DeleteProject(Project project);

    // Status
    Task<Projectstatus> CreateProjectStatus(Projectstatus projectStatus);
    int? FindIfExistsProjectStatus(int projectStatusId);
    Projectstatus? GetProjectStatus(int projectStatusId);
    Projectstatus? GetProjectStatus(string projectStatusName);
    Task<Projectstatus?> UpdateProjectStatus(Projectstatus projectStatus);
    Task<bool> DeleteProjectStatus(Projectstatus projectStatus);
  }
}
