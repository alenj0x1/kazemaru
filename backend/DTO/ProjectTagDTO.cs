namespace backend.DTO
{
  public class ProjectTagDTO
  {
    public Guid ProjectTagId { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
  }
}
