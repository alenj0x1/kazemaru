using backend.DTO;
using backend.Models;
using backend.Models.Request.Project;
using backend.Models.Request.Project.Status;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Contract
{
  public interface IProjectsController
  {
    Task<GenericResponse<ProjectDTO>> CreateProject([FromBody] ProjectCreateRequestModel model);
    GenericResponse<ProjectDTO?> GetProject(Guid projectId);
    GenericResponse<List<ProjectDTO>> GetProjects();
    Task<GenericResponse<ProjectDTO>> UpdateProject(Guid projectId, [FromBody] ProjectUpdateRequestModel model);
    Task<GenericResponse<bool>> DeleteProject(Guid projectId);

    // Status
    Task<GenericResponse<ProjectStatusDTO>> CreateProjectStatus([FromBody] ProjectStatusCreateRequestModel model);
    Task<GenericResponse<ProjectStatusDTO>> UpdateProjectStatus(int projectStatusId, [FromBody] ProjectStatusUpdateRequestModel model);
    Task<GenericResponse<bool>> DeleteProjectStatus(int projectStatusId);
  }
}
