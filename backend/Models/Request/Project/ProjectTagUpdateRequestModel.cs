namespace backend.Models.Request.Project
{
  public class ProjectTagUpdateRequestModel
  {
    public Guid ProjectTagId { get; set; }
    public Guid? ProjectId { get; set; }
    public string? Name { get; set; }
  }
}
