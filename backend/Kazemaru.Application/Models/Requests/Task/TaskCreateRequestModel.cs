using System.ComponentModel.DataAnnotations;
using backend.Helpers;

namespace backend.Kazemaru.Application.Models.Requests.Task;

public class TaskCreateRequestModel
{
    [MaxLength(50, ErrorMessage = ResponseConstants.TaskNameIsLongerThanAllowed)]
    public string Name { get; set; } = null!;

    public Guid ProjectId { get; set; }
    public string? Description { get; set; } = null;
    public int Status { get; set; } = 1;
}