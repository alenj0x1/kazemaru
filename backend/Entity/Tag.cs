using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Tag
{
    public Guid Tagid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Createdat { get; set; }

    public DateTime Updatedat { get; set; }
}
