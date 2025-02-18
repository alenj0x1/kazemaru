using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class ProjectsTag
{
    public Guid TadId { get; set; }

    public Guid ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Tag Tad { get; set; } = null!;
}
