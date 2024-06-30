namespace backend.Models.Request.Task
{
  public class TaskCreateRequestModel
  {
    public string Name { get; set; } = null!;
    public Guid Projectid { get; set; }
    public string? Description { get; set; } = null;
    public int Status { get; set; } = 1;
  }
}
