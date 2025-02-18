using System;
using System.Collections.Generic;

namespace backend.Entity;

public partial class NotesTag
{
    public Guid TagId { get; set; }

    public Guid NoteId { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
