namespace backend.DTO
{
  public class ProjectStatusDTO
  {
    public int StatusId { get; set; }
    public string Name { get; set; } = null!;
    public string? Content { get; set; }
  }
}
