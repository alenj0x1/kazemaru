using System.Security.Claims;
using backend.Kazemaru.Application.Models.Dtos;
using backend.Kazemaru.Application.Models.Requests.Project;
using backend.Kazemaru.Application.Models.Requests.Project.Status;
using backend.Kazemaru.Application.Models.Responses;


namespace backend.Kazemaru.Application.Interfaces.Services;

public interface IProjectService
{
    Task<GenericResponse<ProjectDto>> Create(ProjectCreateRequestModel model, Claim userId);
    GenericResponse<ProjectDto?> Get(Guid projectId);
    GenericResponse<List<ProjectDto>> Get();
    Task<GenericResponse<ProjectDto>> Update(Guid projectId, ProjectUpdateRequestModel model);
    Task<GenericResponse<ProjectDto>> Delete(Guid projectId);

    // Status
    Task<GenericResponse<ProjectStatusDto>> CreateStatus(ProjectStatusCreateRequestModel model);
    GenericResponse<ProjectStatusDto?> GetStatus(int projectStatusId);

    Task<GenericResponse<ProjectStatusDto>> UpdateStatus(
        int projectStatusId,
        ProjectStatusUpdateRequestModel model
    );

    Task<GenericResponse<bool>> DeleteStatus(int projectStatusId);
}