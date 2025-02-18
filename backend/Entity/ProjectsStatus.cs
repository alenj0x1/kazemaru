using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class ProjectsStatus
{
    public int ProjectStatusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string NameColor { get; set; } = null!;

    public string BackgroundColor { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
