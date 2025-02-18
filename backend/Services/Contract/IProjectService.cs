using backend.DTO;
using backend.Models;
using backend.Models.Request.Project;
using backend.Models.Request.Project.Status;

namespace backend.Services.Contract
{
    public interface IProjectService
    {
        Task<GenericResponse<ProjectDTO>> Create(ProjectCreateRequestModel model);
        GenericResponse<ProjectDTO?> Get(Guid projectId);
        GenericResponse<List<ProjectDTO>> Get();
        Task<GenericResponse<ProjectDTO>> Update(Guid projectId, ProjectUpdateRequestModel model);
        Task<GenericResponse<ProjectDTO>> Delete(Guid projectId);

        // Status
        Task<GenericResponse<ProjectStatusDTO>> CreateStatus(ProjectStatusCreateRequestModel model);
        GenericResponse<ProjectStatusDTO?> GetStatus(int projectStatusId);

        Task<GenericResponse<ProjectStatusDTO>> UpdateStatus(int projectStatusId,
            ProjectStatusUpdateRequestModel model);

        Task<GenericResponse<bool>> DeleteStatus(int projectStatusId);
    }
}