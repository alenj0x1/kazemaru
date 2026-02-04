namespace Kazemaru.Application.Models.Dtos;

public class ProjectStatusDto
{
    public int Projectstatusid { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Namecolor { get; set; } = null!;
    public string Backgroundcolor { get; set; } = null!;
}