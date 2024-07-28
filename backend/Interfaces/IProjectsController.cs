using backend.Models.Request.Project;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface IProjectsController
  {
    Task<IActionResult> CreateProject([FromBody] ProjectCreateRequestModel model);
    IActionResult GetProject(Guid projectId);
    IActionResult GetProjects();
    Task<IActionResult> UpdateProject([FromBody] ProjectUpdateRequestModel model);
    Task<IActionResult> DeleteProject(Guid projectId);

    // Status
    Task<IActionResult> CreateProjectStatus([FromBody] ProjectStatusCreateRequestModel model);
    Task<IActionResult> UpdateProjectStatus([FromBody] ProjectStatusUpdateRequestModel model);
    Task<IActionResult> DeleteProjectStatus(int projectStatusId);
  }
}
