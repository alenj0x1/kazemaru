namespace Kazemaru.Domain.Entities;

public partial class Notetag
{
    public Guid Tagid { get; set; }

    public Guid Noteid { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
