using System.ComponentModel.DataAnnotations;
using backend.Helpers;

namespace backend.Kazemaru.Application.Models.Requests.Note;

public class NoteUpdateRequestModel
{
    [MaxLength(100, ErrorMessage = ResponseConstants.NoteTitleIsLongerThanAllowed)]
    public string? Title { get; set; }

    public string? Content { get; set; }

    public Guid? ProjectId { get; set; }

    public Guid? TaskId { get; set; }
}