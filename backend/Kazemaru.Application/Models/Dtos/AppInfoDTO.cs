namespace Kazemaru.Application.Models.Dtos;

public class AppInfoDto
{
    public List<TagDto> Tags { get; set; } = [];
    public List<ProjectStatusDto> ProjectStatuses { get; set; } = [];
    public List<TaskStatusDto> TaskStatuses { get; set; } = [];
}