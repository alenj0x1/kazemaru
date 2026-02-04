using System.ComponentModel.DataAnnotations;
using Kazemaru.Shared;

namespace Kazemaru.Application.Models.Requests.Project;

public class ProjectCreateRequestModel
{
    [MaxLength(50, ErrorMessage = ResponseConstants.ProjectNameIsLongerThanAllowed)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; } = null;
    public string? Banner { get; set; } = null;
    public int Status { get; set; } = 1;
}