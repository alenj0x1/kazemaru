namespace backend.Models.Request.Project
{
  public class ProjectStatusUpdateRequestModel
  {
    public int Projectstatusid { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Namecolor { get; set; }
    public string? Backgroundcolor { get; set; }
  }
}
