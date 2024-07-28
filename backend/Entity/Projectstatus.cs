using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Projectstatus
{
    public int Projectstatusid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Namecolor { get; set; } = null!;

    public string Backgroundcolor { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
