using System.ComponentModel.DataAnnotations;
using Kazemaru.Shared;

namespace Kazemaru.Application.Models.Requests.Task.Status;

public class TaskStatusCreateRequest
{
    [Required]
    [MaxLength(30, ErrorMessage = ResponseConstants.TaskStatusNameIsLongerThanAllowed)]
    public string Name { get; set; } = null!;

    [MaxLength(50, ErrorMessage = ResponseConstants.TaskStatusDescriptionIsLongerThanAllowed)]
    public string? Description { get; set; }

    [MaxLength(30, ErrorMessage = ResponseConstants.TaskStatusNameColorLongerThanAllowed)]
    public string? NameColor { get; set; } = null!;

    [MaxLength(30, ErrorMessage = ResponseConstants.TaskStatusBackgroundColorIsLongerThanAllowed)]
    public string? BackgroundColor { get; set; } = null!;
}