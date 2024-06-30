namespace backend.Models.Request.Note
{
  public class NoteCreateRequestModel
  {
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public Guid? ProjectId { get; set; } = null;

    public Guid? TaskId { get; set; } = null;
  }
}
