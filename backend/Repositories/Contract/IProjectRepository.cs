using backend.Entity;
using backend.Models.Request.Project;

namespace backend.Repositories.Contract
{
  public interface IProjectRepository
  {
    Task<Project> CreateProject(ProjectCreateRequestModel model);
    Project? GetProject(Guid projectId);
    Project? GetProject(string projectName);
    List<Project> GetProjects();
    Task<Project?> UpdateProject(ProjectUpdateRequestModel model);
    Task<bool> DeleteProject(Guid projectId);

    // Status
    Task<Projectstatus> CreateProjectStatus(ProjectStatusCreateRequestModel model);
    Projectstatus? GetProjectStatus(int projectStatusId);
    Projectstatus? GetProjectStatus(string projectStatusName);
    Task<Projectstatus?> UpdateProjectStatus(ProjectStatusUpdateRequestModel model);
    Task<bool> DeleteProjectStatus(int projectStatusId);
  }
}
