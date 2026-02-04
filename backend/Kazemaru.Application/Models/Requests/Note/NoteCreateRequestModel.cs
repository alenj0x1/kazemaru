using System.ComponentModel.DataAnnotations;
using Kazemaru.Shared;

namespace Kazemaru.Application.Models.Requests.Note;

public class NoteCreateRequestModel
{
    [Required]
    [MaxLength(100, ErrorMessage = ResponseConstants.NoteTitleIsLongerThanAllowed)]
    public string Title { get; set; } = null!;

    [Required] public string Content { get; set; } = null!;

    public Guid? ProjectId { get; set; } = null;

    public Guid? TaskId { get; set; } = null;
}