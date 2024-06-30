namespace backend.Models.Request.Note
{
  public class NoteTagCreateRequestModel
  {
    public Guid NoteId { get; set; }
    public string Name { get; set; } = null!;
  }
}
