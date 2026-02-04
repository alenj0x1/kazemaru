using System.Security.Claims;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Requests.Project;
using Kazemaru.Application.Models.Requests.Project.Status;
using Kazemaru.Application.Models.Responses;


namespace Kazemaru.Application.Interfaces.Services;

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