using System.ComponentModel.DataAnnotations;
using backend.Tools;

namespace backend.Models.Request.Project.Status
{
  public class ProjectStatusUpdateRequestModel
  {
    [MaxLength(30, ErrorMessage = ResponseConstants.ProjectStatusNameIsLongerThanAllowed)]
    public string? Name { get; set; }
    [MaxLength(50, ErrorMessage = ResponseConstants.ProjectStatusDescriptionIsLongerThanAllowed)]
    public string? Description { get; set; }
    [MaxLength(30, ErrorMessage = ResponseConstants.ProjectStatusNameColorIsLongerThanAllowed)]
    public string? NameColor { get; set; }
    [MaxLength(30, ErrorMessage = ResponseConstants.ProjectStatusBackgroundColorIsLongerThanAllowed)]
    public string? BackgroundColor { get; set; }
  }
}
