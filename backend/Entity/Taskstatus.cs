using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Taskstatus
{
    public int Taskstatusid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Namecolor { get; set; } = null!;

    public string Backgroundcolor { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
