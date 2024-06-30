namespace backend.Models.Request.Note
{
  public class NoteUpdateRequestModel
  {
    public Guid NoteId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public Guid? ProjectId { get; set; }

    public Guid? TaskId { get; set; }
  }
}
