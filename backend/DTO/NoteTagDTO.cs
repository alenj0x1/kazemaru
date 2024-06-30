namespace backend.DTO
{
  public class NoteTagDTO
  {
    public Guid NoteTagId { get; set; }
    public Guid NoteId { get; set; }
    public string Name { get; set; } = null!;
  }
}
