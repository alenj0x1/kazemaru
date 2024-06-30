namespace backend.Models.Request.Task
{
  public class TaskUpdateRequestModel
  {
    public Guid TaskId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? Projectid { get; set; }
    public int? Status { get; set; }
  }
}
