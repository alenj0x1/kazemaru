using backend.Models.Request.Note;
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

    // Project tag
    Task<IActionResult> CreateProjectTag([FromBody] ProjectTagCreateRequestModel model);
    IActionResult GetProjectTag(Guid projectTagId);
    IActionResult GetProjectTags();
    Task<IActionResult> UpdateProjectTag([FromBody] ProjectTagUpdateRequestModel model);
    Task<IActionResult> DeleteProjectTag(Guid projectTagId);
  }
}
