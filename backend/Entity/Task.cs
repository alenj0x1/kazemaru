using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Task
{
    public Guid Taskid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Statusid { get; set; }

    public Guid Projectid { get; set; }

    public DateTime Createdat { get; set; }

    public DateTime Updatedat { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Project Project { get; set; } = null!;

    public virtual Taskstatus Status { get; set; } = null!;
}
