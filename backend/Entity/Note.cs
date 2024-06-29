using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Note
{
    public Guid Noteid { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public Guid? Project { get; set; }

    public Guid? Task { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual Project? ProjectNavigation { get; set; }

    public virtual Task? TaskNavigation { get; set; }
}
