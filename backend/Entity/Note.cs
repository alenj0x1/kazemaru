using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Note
{
    public Guid Noteid { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public Guid? Projectid { get; set; }

    public Guid? Taskid { get; set; }

    public DateTime Createdat { get; set; }

    public DateTime Updatedat { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Task? Task { get; set; }
}
