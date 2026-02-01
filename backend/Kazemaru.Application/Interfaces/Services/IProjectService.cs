using System.Security.Claims;
using backend.DTO;
using backend.Kazemaru.Application.Models.Requests.Project;
using backend.Kazemaru.Application.Models.Requests.Project.Status;
using backend.Kazemaru.Application.Models.Responses;


namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IProjectService
{
    Task<GenericResponse<ProjectDTO>> Create(ProjectCreateRequestModel model, Claim userId);
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