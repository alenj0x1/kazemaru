namespace Kazemaru.Application.Models.Dtos;

public class TagDto
{
    public Guid Tagid { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? Createdat { get; set; }
    public DateTime? Updatedat { get; set; }
}