using System.ComponentModel.DataAnnotations;
using backend.Helpers;

namespace backend.Models.Request.Project.Status
{
    public class ProjectStatusCreateRequestModel
    {
        [MaxLength(30, ErrorMessage = ResponseConstants.ProjectNameIsLongerThanAllowed)]
        public string Name { get; set; } = null!;

        [MaxLength(50, ErrorMessage = ResponseConstants.ProjectStatusDescriptionIsLongerThanAllowed)]
        public string? Description { get; set; }

        [MaxLength(30, ErrorMessage = ResponseConstants.ProjectStatusNameColorIsLongerThanAllowed)]
        public string NameColor { get; set; } = null!;

        [MaxLength(30, ErrorMessage = ResponseConstants.ProjectStatusBackgroundColorIsLongerThanAllowed)]
        public string BackgroundColor { get; set; } = null!;
    }
}