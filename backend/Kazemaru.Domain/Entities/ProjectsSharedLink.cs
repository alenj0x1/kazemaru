namespace Kazemaru.Domain.Entities;

public partial class ProjectsSharedLink
{
    public Guid ProjectSharedLinkId { get; set; }

    public Guid ProjectId { get; set; }

    public string Value { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Project Project { get; set; } = null!;
}
