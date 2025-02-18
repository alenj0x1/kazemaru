using System.ComponentModel.DataAnnotations;
using backend.Tools;

namespace backend.Models.Request.Task
{
    public class TaskUpdateRequestModel
    {
        [MaxLength(50, ErrorMessage = ResponseConstants.TaskNameIsLongerThanAllowed)]
        public string Name { get; set; } = null!;

        public Guid? ProjectId { get; set; }
        public string? Description { get; set; } = null;
        public int? Status { get; set; } = 1;
    }
}