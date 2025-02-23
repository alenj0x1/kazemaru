namespace backend.Entity.Postgres;

public partial class TasksStatus
{
    public int TaskStatusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string NameColor { get; set; } = null!;

    public string BackgroundColor { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
