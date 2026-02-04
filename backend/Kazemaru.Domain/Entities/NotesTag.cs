namespace Kazemaru.Domain.Entities;

public partial class NotesTag
{
    public Guid TagId { get; set; }

    public Guid NoteId { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
