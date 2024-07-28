using backend.Models.Request.Task;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface IAppController
  {
    IActionResult Info();
  }
}
