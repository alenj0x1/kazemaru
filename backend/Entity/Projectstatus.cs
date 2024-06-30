using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Projectstatus
{
    public int Statusid { get; set; }
    public string Name { get; set; } = null!;
    public string? Content { get; set; }
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
