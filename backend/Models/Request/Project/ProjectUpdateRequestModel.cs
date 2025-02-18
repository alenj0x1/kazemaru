using System.ComponentModel.DataAnnotations;
using backend.Helpers;

namespace backend.Models.Request.Project
{
    public class ProjectUpdateRequestModel
    {
        [MaxLength(50, ErrorMessage = ResponseConstants.ProjectNameIsLongerThanAllowed)]
        public string? Name { get; set; } = null;

        public string? Description { get; set; } = null;
        public string? Banner { get; set; } = null;
        public int? Status { get; set; }
    }
}