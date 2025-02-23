namespace backend.Entity.Postgres;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordHint { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<ProjectsBlacklist> ProjectsBlacklists { get; set; } = new List<ProjectsBlacklist>();

    public virtual ICollection<ProjectsMember> ProjectsMembers { get; set; } = new List<ProjectsMember>();
}
