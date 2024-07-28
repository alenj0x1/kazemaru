using backend.Models.Request.Project;
using backend.Models.Request.Task;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface ITasksController
  {
    Task<IActionResult> CreateTask([FromBody] TaskCreateRequestModel model);
    IActionResult GetTask(Guid taskId);
    IActionResult GetTasks();
    Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestModel model);
    Task<IActionResult> DeleteTask(Guid taskId);

    // Status
    Task<IActionResult> CreateTaskStatus([FromBody] TaskStatusCreateRequest model);
    Task<IActionResult> UpdateTaskStatus([FromBody] TaskStatusUpdateRequest model);
    Task<IActionResult> DeleteTaskStatus(int taskStatusId);
  }
}
