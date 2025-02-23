namespace backend.Entity.Postgres;

public partial class Project
{
    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public Guid OwnerId { get; set; }

    public string? Banner { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<ProjectsBlacklist> ProjectsBlacklists { get; set; } = new List<ProjectsBlacklist>();

    public virtual ICollection<ProjectsMember> ProjectsMembers { get; set; } = new List<ProjectsMember>();

    public virtual ICollection<ProjectsSharedLink> ProjectsSharedLinks { get; set; } = new List<ProjectsSharedLink>();

    public virtual ProjectsStatus Status { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
