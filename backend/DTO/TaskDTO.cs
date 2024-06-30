namespace backend.DTO
{
  public class TaskDTO
  {
    public Guid Taskid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? Status { get; set; }

    public Guid Projectid { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }
  }
}
