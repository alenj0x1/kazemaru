using backend.Entity;
using backend.Models.Request.Project;

namespace backend.Repositories.Contract
{
  public interface IProjectRepository
  {
    // Project
    Task<Project> CreateProject(KazemarudbContext db, ProjectCreateRequestModel model);
    Project? GetProject(KazemarudbContext db, Guid projectId);
    Project? GetProject(KazemarudbContext db, string projectName);
    List<Project> GetProjects(KazemarudbContext db);
    Task<Project?> UpdateProject(KazemarudbContext db, ProjectUpdateRequestModel model);
    Task<bool> DeleteProject(KazemarudbContext db, Guid projectId);

    // Project status
    Task<Projectstatus> CreateProjectStatus(KazemarudbContext db, ProjectStatusCreateRequestModel model);
    Projectstatus? GetProjectStatus(KazemarudbContext db, string statusName);
    Projectstatus? GetProjectStatus(KazemarudbContext db, int statusId);
    List<Projectstatus> GetAllProjectStatus(KazemarudbContext db);
    Task<Projectstatus?> UpdateProjectStatus(KazemarudbContext db, ProjectStatusUpdateRequestModel model);
    Task<bool> DeleteProjectStatus(KazemarudbContext db, string statusName);
  }
}
