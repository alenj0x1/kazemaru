namespace backend.Models.Request.Note
{
  public class NoteTagUpdateRequestModel
  {
    public Guid NoteTagId { get; set; }
    public Guid? NoteId { get; set; }
    public string? Name { get; set; }
  }
}
