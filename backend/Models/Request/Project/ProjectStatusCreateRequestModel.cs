namespace backend.Models.Request.Project
{
  public class ProjectStatusCreateRequestModel
  {
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Namecolor { get; set; } = null!;
    public string Backgroundcolor { get; set; } = null!;
  }
}
