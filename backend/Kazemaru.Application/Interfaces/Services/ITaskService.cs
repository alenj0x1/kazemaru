using backend.DTO;
using backend.Kazemaru.Application.Models.Requests.Task;
using backend.Kazemaru.Application.Models.Requests.Task.Status;
using backend.Kazemaru.Application.Models.Responses;


namespace backend.Kazemaru.Application.Interfaces.Services;

public interface ITaskService
{
    Task<GenericResponse<TaskDTO>> Create(TaskCreateRequestModel model);
    GenericResponse<TaskDTO?> Get(Guid taskId);
    GenericResponse<List<TaskDTO>> Get();
    Task<GenericResponse<TaskDTO>> Update(Guid taskId, TaskUpdateRequestModel model);
    Task<GenericResponse<TaskDTO>> Delete(Guid taskId);

    // Status
    Task<GenericResponse<TaskStatusDTO>> CreateStatus(TaskStatusCreateRequest model);
    GenericResponse<TaskStatusDTO?> GetStatus(int taskStatusId);
    Task<GenericResponse<TaskStatusDTO>> UpdateStatus(int taskStatusId, TaskStatusUpdateRequest model);
    Task<GenericResponse<bool>> DeleteStatus(int taskStatusId);
}