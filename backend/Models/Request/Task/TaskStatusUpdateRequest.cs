namespace backend.Models.Request.Task
{
  public class TaskStatusUpdateRequest
  {
    public int TaskStatusId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Namecolor { get; set; }
    public string? Backgroundcolor { get; set; }
  }
}
