namespace backend.DTO
{
  public class AppInfoDTO
  {
    public List<TagDTO> Tags { get; set; } = [];
    public List<ProjectStatusDTO> ProjectStatuses { get; set; } = [];
    public List<TaskStatusDTO> TaskStatuses { get; set; } = [];
  }
}
