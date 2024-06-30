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
        if (_repTask.GetTaskStatus(_db, model.Status) is null) throw new Exception($"The task status with ID: '{model.Status}' does not exist.");
        if (_repProj.GetProject(_db, model.Projectid) is null) throw new Exception($"The project with ID: '{model.Projectid}' does not exist.");

        return _mapper.Map<TaskDTO>(await _repTask.CreateTask(_db, model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public TaskDTO GetTask(string taskName)
    {
      try
      {
        Entity.Task task = _repTask.GetTask(_db, taskName) ?? throw new Exception($"The task with name: '{taskName}' does not exist.");
        return _mapper.Map<TaskDTO>(task);
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
        Entity.Task task = _repTask.GetTask(_db, taskId) ?? throw new Exception($"The task with id: '{taskId}' does not exist.");
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
        return _mapper.Map<List<TaskDTO>>(_repTask.GetTasks(_db));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<TaskDTO> GetTasks(string taskName)
    {
      try
      {
        return _mapper.Map<List<TaskDTO>>(_repTask.GetTasks(_db, taskName));
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
        if (_repTask.GetTask(_db, model.TaskId) is null) throw new Exception($"The task with ID: '{model.TaskId}' does not exist.");
        if (model.Name is not null && model.Name.Length > 50) throw new Exception("The task name length is longer than allowed.");
        if (model.Status is not null && _repTask.GetTaskStatus(_db, Convert.ToInt32(model.Status)) is null) throw new Exception($"The task status with ID: '{model.Status}' does not exist.");
        if (model.Projectid.HasValue && _repProj.GetProject(_db, model.Projectid.Value) is null) throw new Exception($"The project with ID: '{model.Projectid}' does not exist.");

        return _mapper.Map<TaskDTO>(await _repTask.UpdateTask(_db, model));
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
        if (_repTask.GetTask(_db, taskId) is null) throw new Exception($"The task with id: '{taskId}' does not exist.");

        return await _repTask.DeleteTask(_db, taskId);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
