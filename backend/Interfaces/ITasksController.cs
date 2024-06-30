using backend.Models.Request.Task;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface ITasksController
  {
    Task<IActionResult> CreateTask([FromBody] TaskCreateRequestModel model);
    IActionResult GetTask(string taskName);
    IActionResult GetTask(Guid taskId);
    IActionResult GetTasks();
    IActionResult GetTasks(string taskName);
    Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestModel model);
    Task<IActionResult> DeleteTask(Guid taskId);
  }
}
