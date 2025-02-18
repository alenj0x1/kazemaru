using System.ComponentModel.DataAnnotations;
using backend.Tools;

namespace backend.Models.Request.Note
{
    public class NoteUpdateRequestModel
    {
        [MaxLength(100, ErrorMessage = ResponseConstants.NoteTitleIsLongerThanAllowed)]
        public string? Title { get; set; }

        public string? Content { get; set; }

        public Guid? ProjectId { get; set; }

        public Guid? TaskId { get; set; }
    }
}