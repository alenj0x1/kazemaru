using backend.DTO;
using backend.Models.Request.Project;

namespace backend.Services.Contract
{
  public interface IProjectService
  {
    Task<ProjectDTO> CreateProject(ProjectCreateRequestModel model);
    ProjectDTO GetProject(Guid projectId);
    List<ProjectDTO> GetProjects();
    Task<ProjectDTO> UpdateProject(ProjectUpdateRequestModel model);
    Task<bool> DeleteProject(Guid projectId);

    // Status
    Task<ProjectStatusDTO> CreateProjectStatus(ProjectStatusCreateRequestModel model);
    ProjectStatusDTO GetProjectStatus(int projectStatusId);
    Task<ProjectStatusDTO> UpdateProjectStatus(ProjectStatusUpdateRequestModel model);
    Task<bool> DeleteProjectStatus(int projectStatusId);
  }
}
