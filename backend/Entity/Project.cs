using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Project
{
    public Guid Projectid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Status { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Projectstatus? StatusNavigation { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
