namespace Kazemaru.Application.Models.Dtos;

public class ProjectDto
{
    public Guid Projectid { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ProjectStatusDto Status { get; set; }
    public List<TagDto> Tags { get; set; }
    public string? banner { get; set; }
    public DateTime? Createdat { get; set; }
    public DateTime? Updatedat { get; set; }
}