using System.ComponentModel.DataAnnotations;
using backend.Tools;

namespace backend.Models.Request.Project
{
    public class ProjectCreateRequestModel
    {
        [MaxLength(50, ErrorMessage = ResponseConstants.ProjectNameIsLongerThanAllowed)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        public string? Banner { get; set; } = null;
        public int Status { get; set; } = 1;
    }
}