namespace backend.DTO
{
  public class TagDTO
  {
    public Guid Tagid { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? Createdat { get; set; }
    public DateTime? Updatedat { get; set; }
  }
}
