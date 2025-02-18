using backend.DTO;
using backend.Models;
using backend.Models.Request.Project;
using backend.Models.Request.Project.Status;

namespace backend.Services.Contract
{
    public interface IProjectService
    {
        Task<GenericResponse<ProjectDTO>> CreateProject(ProjectCreateRequestModel model);
        GenericResponse<ProjectDTO?> GetProject(Guid projectId);
        GenericResponse<List<ProjectDTO>> GetProjects();
        Task<GenericResponse<ProjectDTO>> UpdateProject(Guid projectId, ProjectUpdateRequestModel model);
        Task<GenericResponse<bool>> DeleteProject(Guid projectId);

        // Status
        Task<GenericResponse<ProjectStatusDTO>> CreateProjectStatus(ProjectStatusCreateRequestModel model);
        GenericResponse<ProjectStatusDTO?> GetProjectStatus(int projectStatusId);

        Task<GenericResponse<ProjectStatusDTO>> UpdateProjectStatus(int projectStatusId,
            ProjectStatusUpdateRequestModel model);

        Task<GenericResponse<bool>> DeleteProjectStatus(int projectStatusId);
    }
}