using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Taskstatus
{
    public int Statusid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
