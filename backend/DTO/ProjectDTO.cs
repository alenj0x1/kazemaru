namespace backend.DTO
{
  public class ProjectDTO
  {
    public Guid Projectid { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ProjectStatusDTO Status { get; set; }
    public List<TagDTO> Tags { get; set; }
    public string? banner { get; set; }
    public DateTime? Createdat { get; set; }
    public DateTime? Updatedat { get; set; }
  }
}