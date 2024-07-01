namespace backend.Models.Request.Project
{
  public class ProjectTagCreateRequestModel
  {
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
  }
}
