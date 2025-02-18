using backend.DTO;
using backend.Models;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;

namespace backend.Services.Contract
{
    public interface ITaskService
    {
        Task<GenericResponse<TaskDTO>> CreateTask(TaskCreateRequestModel model);
        GenericResponse<TaskDTO?> GetTask(Guid taskId);
        GenericResponse<List<TaskDTO>> GetTasks();
        Task<GenericResponse<TaskDTO>> UpdateTask(Guid taskId, TaskUpdateRequestModel model);
        Task<GenericResponse<bool>> DeleteTask(Guid taskId);

        // Status
        Task<GenericResponse<TaskStatusDTO>> CreateTaskStatus(TaskStatusCreateRequest model);
        GenericResponse<TaskStatusDTO?> GetTaskStatus(int taskStatusId);
        Task<GenericResponse<TaskStatusDTO>> UpdateTaskStatus(int taskStatusId, TaskStatusUpdateRequest model);
        Task<GenericResponse<bool>> DeleteTaskStatus(int taskStatusId);
    }
}