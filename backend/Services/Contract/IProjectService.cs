using backend.DTO;
using backend.Models.Request.Project;

namespace backend.Services.Contract
{
  public interface IProjectService
  {
    // Project
    Task<ProjectDTO> CreateProject(ProjectCreateRequestModel model);
    ProjectDTO GetProject(Guid projectId);
    ProjectDTO GetProject(string projectName);
    List<ProjectDTO> GetProjects();
    Task<ProjectDTO> UpdateProject(ProjectUpdateRequestModel model);
    Task<bool> DeleteProject(Guid projectId);

    // Project status
    Task<ProjectStatusDTO> CreateProjectStatus(ProjectStatusCreateRequestModel model);
    ProjectStatusDTO GetProjectStatus(string statusName);
    List<ProjectStatusDTO> GetAllProjectStatus();
    Task<ProjectStatusDTO> UpdateProjectStatus(ProjectStatusUpdateRequestModel model);
    Task<bool> DeleteProjectStatus(string statusName);

    // Project tag
    Task<ProjectTagDTO> CreateProjectTag(ProjectTagCreateRequestModel model);
    ProjectTagDTO GetProjectTag(Guid projectTagId);
    List<ProjectTagDTO> GetProjectTags();
    Task<ProjectTagDTO> UpdateProjectTag(ProjectTagUpdateRequestModel model);
    Task<bool> DeleteProjectTag(Guid projectTagId);
  }
}
