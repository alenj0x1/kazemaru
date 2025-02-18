using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class ProjectsBlacklist
{
    public int ProjectBlacklistId { get; set; }

    public Guid ProjectId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
