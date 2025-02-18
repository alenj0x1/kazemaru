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
    Task<ProjectsStatus> CreateProjectStatus(ProjectsStatus projectStatus);
    int? FindIfExistsProjectStatus(int projectStatusId);
    ProjectsStatus? GetProjectStatus(int projectStatusId);
    ProjectsStatus? GetProjectStatus(string projectStatusName);
    Task<ProjectsStatus?> UpdateProjectStatus(ProjectsStatus projectStatus);
    Task<bool> DeleteProjectStatus(ProjectsStatus projectStatus);
  }
}
