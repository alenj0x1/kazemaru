using backend.Kazemaru.Application.Models.Dtos;
using backend.Kazemaru.Application.Models.Requests.Task;
using backend.Kazemaru.Application.Models.Requests.Task.Status;
using backend.Kazemaru.Application.Models.Responses;


namespace backend.Kazemaru.Application.Interfaces.Services;

public interface ITaskService
{
    Task<GenericResponse<TaskDto>> Create(TaskCreateRequestModel model);
    GenericResponse<TaskDto?> Get(Guid taskId);
    GenericResponse<List<TaskDto>> Get();
    Task<GenericResponse<TaskDto>> Update(Guid taskId, TaskUpdateRequestModel model);
    Task<GenericResponse<TaskDto>> Delete(Guid taskId);

    // Status
    Task<GenericResponse<TaskStatusDto>> CreateStatus(TaskStatusCreateRequest model);
    GenericResponse<TaskStatusDto?> GetStatus(int taskStatusId);
    Task<GenericResponse<TaskStatusDto>> UpdateStatus(int taskStatusId, TaskStatusUpdateRequest model);
    Task<GenericResponse<bool>> DeleteStatus(int taskStatusId);
}