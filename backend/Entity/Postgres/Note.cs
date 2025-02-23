namespace backend.Entity.Postgres;

public partial class Note
{
    public Guid NoteId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public Guid? ProjectId { get; set; }

    public Guid? TaskId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Task? Task { get; set; }
}
