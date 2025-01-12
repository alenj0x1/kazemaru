using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;
using backend.Repositories.Contract;
using backend.Services.Contract;
using backend.Tools;
using Task = backend.Entity.Task;

namespace backend.Services
{
  public class TaskService(KazemarudbContext db, ITaskRepository repTask, IProjectRepository repProj, IMapper mapper) : ITaskService
  {
    private readonly KazemarudbContext _db = db;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IProjectRepository _repProj = repProj;
    private readonly IMapper _mapper = mapper;

    public async Task<GenericResponse<TaskDTO>> CreateTask(TaskCreateRequestModel model)
    {
      try
      {
        if (_repTask.GetTaskStatus(model.Status) is null) throw new Exception(ResponseConstants.TaskStatusNotExists(model.Status));
        if (_repProj.GetProject(model.ProjectId) is null) throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId));

        var createTask = await _repTask.CreateTask(new Task
        {
          Name = model.Name,
          Description = model.Description,
          Statusid = model.Status
        });
        var mapper = _mapper.Map<TaskDTO>(createTask);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public GenericResponse<TaskDTO?> GetTask(Guid taskId)
    {
      try
      {
        var task = _repTask.GetTask(taskId) ?? throw new Exception(ResponseConstants.TaskNotExists(taskId));
        var mapper = _mapper.Map<TaskDTO?>(task);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public GenericResponse<List<TaskDTO>> GetTasks()
    {
      try
      {
        var findTasks = _repTask.GetTasks();
        var mapper = _mapper.Map<List<TaskDTO>>(findTasks);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<TaskDTO>> UpdateTask(Guid taskId, TaskUpdateRequestModel model)
    {
      try
      {
        if (taskId == Guid.Empty) throw new Exception(ResponseConstants.TaskIdIsRequired);
        
        var findTask = _repTask.GetTask(taskId) ?? throw new Exception(ResponseConstants.TaskNotExists(taskId));
        
        if (model.Status.HasValue && _repTask.GetTaskStatus(model.Status.Value) is null) throw new Exception(ResponseConstants.TaskStatusNotExists(model.Status.Value));
        if (model.ProjectId.HasValue && _repProj.GetProject(model.ProjectId.Value) is null) throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId.Value));

        findTask.Name = model.Name ?? findTask.Name;
        findTask.Description = model.Description ?? findTask.Description;
        findTask.Statusid = model.Status ?? findTask.Statusid;
        
        var updateTask = await _repTask.UpdateTask(findTask);
        var mapper = _mapper.Map<TaskDTO>(updateTask);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<bool>> DeleteTask(Guid taskId)
    {
      try
      {
        if (taskId == Guid.Empty) throw new Exception(ResponseConstants.TaskIdIsRequired);
        
        var findTask = _repTask.GetTask(taskId) ?? throw new Exception(ResponseConstants.TaskNotExists(taskId));
        
        var deleteTask = await _repTask.DeleteTask(findTask);
        return ManageResponse.Create(deleteTask);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    public async Task<GenericResponse<TaskStatusDTO>> CreateTaskStatus(TaskStatusCreateRequest model)
    {
      try
      {
        if (_repTask.GetTaskStatus(model.Name) is not null) throw new Exception(ResponseConstants.TaskStatusCreatedPreviously);

        var createTaskStatus = await _repTask.CreateTaskStatus(new Taskstatus
        {
          Name = model.Name,
          Description = model.Description,
          Backgroundcolor = model.BackgroundColor,
          Namecolor = model.NameColor
        });
        var mapper = _mapper.Map<TaskStatusDTO>(createTaskStatus);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public GenericResponse<TaskStatusDTO?> GetTaskStatus(int taskStatusId)
    {
      try
      {
        var findTaskStatus = _repTask.GetTaskStatus(taskStatusId) ?? throw new Exception(ResponseConstants.TaskStatusNotExists(taskStatusId));
        var mapper = _mapper.Map<TaskStatusDTO?>(findTaskStatus);
        
        return ManageResponse.Create(mapper); ;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<TaskStatusDTO>> UpdateTaskStatus(int taskStatusId, TaskStatusUpdateRequest model)
    {
      try
      {
        var findTaskStatus = _repTask.GetTaskStatus(taskStatusId) ?? throw new Exception(ResponseConstants.TaskStatusNotExists(taskStatusId));
        
        findTaskStatus.Name = model.Name ?? findTaskStatus.Name;
        findTaskStatus.Description = model.Description ?? findTaskStatus.Description;
        findTaskStatus.Namecolor = model.NameColor ?? findTaskStatus.Namecolor;
        findTaskStatus.Backgroundcolor = model.BackgroundColor ?? findTaskStatus.Backgroundcolor;
        
        var updateTaskStatus = await _repTask.UpdateTaskStatus(findTaskStatus);
        var mapper = _mapper.Map<TaskStatusDTO>(updateTaskStatus);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<bool>> DeleteTaskStatus(int taskStatusId)
    {
      try
      {
        var findTaskStatus = _repTask.GetTaskStatus(taskStatusId) ?? throw new Exception(ResponseConstants.TaskStatusNotExists(taskStatusId));

        var deleteTaskStatus = await _repTask.DeleteTaskStatus(findTaskStatus);
        return ManageResponse.Create(deleteTaskStatus);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
