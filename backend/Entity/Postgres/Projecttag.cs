namespace backend.Entity.Postgres;

public partial class Projecttag
{
    public Guid Tagid { get; set; }

    public Guid Projectid { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
