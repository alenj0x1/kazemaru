using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models.Request.Task;
using backend.Repositories.Contract;
using backend.Services.Contract;

namespace backend.Services
{
  public class TaskService(KazemarudbContext db, ITaskRepository repTask, IProjectRepository repProj, IMapper mapper) : ITaskService
  {
    private readonly KazemarudbContext _db = db;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IProjectRepository _repProj = repProj;
    private readonly IMapper _mapper = mapper;

    public async Task<TaskDTO> CreateTask(TaskCreateRequestModel model)
    {
      try
      {
        if (model.Name.Length > 50) throw new Exception("The task name length is longer than allowed.");
        if (_repTask.GetTaskStatus(model.Status) is null) throw new Exception($"The task status with ID: '{model.Status}' does not exist.");
        if (_repProj.GetProject(model.Projectid) is null) throw new Exception($"The project with ID: '{model.Projectid}' does not exist.");

        return _mapper.Map<TaskDTO>(await _repTask.CreateTask(model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public TaskDTO GetTask(Guid taskId)
    {
      try
      {
        Entity.Task task = _repTask.GetTask(taskId) ?? throw new Exception($"The task with id: '{taskId}' does not exist.");
        return _mapper.Map<TaskDTO>(task);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<TaskDTO> GetTasks()
    {
      try
      {
        return _mapper.Map<List<TaskDTO>>(_repTask.GetTasks());
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<TaskDTO?> UpdateTask(TaskUpdateRequestModel model)
    {
      try
      {
        if (model.TaskId == Guid.Empty) throw new Exception("The task id is a required field");
        if (_repTask.GetTask(model.TaskId) is null) throw new Exception($"The task with ID: '{model.TaskId}' does not exist.");
        if (model.Name is not null && model.Name.Length > 50) throw new Exception("The task name length is longer than allowed.");
        if (model.Status.HasValue && _repTask.GetTaskStatus(model.Status.Value) is null) throw new Exception($"The task status with ID: '{model.Status}' does not exist.");
        if (model.Projectid.HasValue && _repProj.GetProject(model.Projectid.Value) is null) throw new Exception($"The project with ID: '{model.Projectid}' does not exist.");

        return _mapper.Map<TaskDTO>(await _repTask.UpdateTask(model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteTask(Guid taskId)
    {
      try
      {
        if (taskId == Guid.Empty) throw new Exception("The task id is a required field");
        if (_repTask.GetTask(taskId) is null) throw new Exception($"The task with id: '{taskId}' does not exist.");

        return await _repTask.DeleteTask(taskId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    public async Task<TaskStatusDTO> CreateTaskStatus(TaskStatusCreateRequest model)
    {
      try
      {
        if (_repTask.GetTaskStatus(model.Name) is not null) throw new Exception("The project status was previously created");
        if (model.Name.Length > 30) throw new Exception("The project status name length is longer than allowed.");
        if (model.Description is not null && model.Description.Length > 50) throw new Exception("The project status content length is longer than allowed.");

        return _mapper.Map<TaskStatusDTO>(await _repTask.CreateTaskStatus(model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public TaskStatusDTO GetTaskStatus(int taskStatusId)
    {
      try
      {
        Taskstatus? gtTaskStatus = _repTask.GetTaskStatus(taskStatusId) ?? throw new Exception($"The task status with id: '{taskStatusId}' does not exist.");
        return _mapper.Map<TaskStatusDTO>(gtTaskStatus); ;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<TaskStatusDTO> UpdateTaskStatus(TaskStatusUpdateRequest model)
    {
      try
      {
        if (_repTask.GetTaskStatus(model.TaskStatusId) is null) throw new Exception("The task status has not been created");

        Taskstatus? updTaskStatus = await _repTask.UpdateTaskStatus(model) ?? throw new Exception("The task status was not updated correctly");

        return _mapper.Map<TaskStatusDTO>(updTaskStatus);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteTaskStatus(int taskStatusId)
    {
      try
      {
        if (_repTask.GetTaskStatus(taskStatusId) is null) throw new Exception("The task status has not been created");

        return await _repTask.DeleteTaskStatus(taskStatusId);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
