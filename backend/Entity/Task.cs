using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Task
{
    public Guid TaskId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public Guid ProjectId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Project Project { get; set; } = null!;

    public virtual TasksStatus Status { get; set; } = null!;
}
