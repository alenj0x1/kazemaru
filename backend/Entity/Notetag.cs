using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class Notetag
{
    public Guid Noteid { get; set; }

    public string Name { get; set; } = null!;
}
