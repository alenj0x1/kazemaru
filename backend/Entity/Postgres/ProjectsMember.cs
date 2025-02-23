namespace backend.Entity.Postgres;

public partial class ProjectsMember
{
    public int ProjectMemberId { get; set; }

    public Guid ProjectId { get; set; }

    public Guid UserId { get; set; }

    public DateTime JoinedAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
