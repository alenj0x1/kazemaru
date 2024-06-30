using backend.Models.Request.Project;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface IProjectController
  {
    // Project
    Task<IActionResult> CreateProject([FromBody] ProjectCreateRequestModel model);
    IActionResult GetProject(Guid projectId);
    IActionResult GetProject(string projectName);
    IActionResult GetProjects();
    Task<IActionResult> UpdateProject([FromBody] ProjectUpdateRequestModel model);
    Task<IActionResult> DeleteProject(Guid projectId);

    // Project status
    Task<IActionResult> CreateProjectStatus([FromBody] ProjectStatusCreateRequestModel model);
    IActionResult GetProjectStatus(string statusName);
    IActionResult GetAllProjectStatus();
    Task<IActionResult> UpdateProjectStatus([FromBody] ProjectStatusUpdateRequestModel model);
    Task<IActionResult> DeleteProjectStatus(string statusName);
  }
}
