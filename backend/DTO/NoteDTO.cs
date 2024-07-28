namespace backend.DTO
{
  public class NoteDTO
  {
    public Guid NoteId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid? ProjectId { get; set; }
    public Guid? TaskId { get; set; }
    public List<TagDTO> Tags { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}
