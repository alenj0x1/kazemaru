using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Projecttag
{
    public Guid Projecttagid { get; set; }

    public Guid Projectid { get; set; }

    public string Name { get; set; } = null!;
}
