namespace Kazemaru.Application.Models.Dtos;

public class NoteDto
{
    public Guid NoteId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid? ProjectId { get; set; }
    public Guid? TaskId { get; set; }
    public List<TagDto> Tags { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}