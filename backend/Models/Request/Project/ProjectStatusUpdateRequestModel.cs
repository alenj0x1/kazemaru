namespace backend.Models.Request.Project
{
  public class ProjectStatusUpdateRequestModel
  {
    public string Name { get; set; } = null!;
    public string? Content { get; set; } = null;
  }
}
