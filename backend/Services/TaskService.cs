using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Entity.Postgres;
using backend.Models;
using backend.Models.Request.Task;
using backend.Models.Request.Task.Status;
using backend.Repositories.Contract;
using backend.Services.Contract;
using backend.Helpers;
using backend.Repositories;
using Task = backend.Entity.Postgres.Task;

namespace backend.Services
{
    public class TaskService(KazemaruDbContext db, TaskRepository repTask, ProjectRepository repProj, IMapper mapper)
        : ITaskService
    {
        private readonly KazemaruDbContext _db = db;
        private readonly TaskRepository _repTask = repTask;
        private readonly ProjectRepository _repProj = repProj;
        private readonly IMapper _mapper = mapper;

        public async Task<GenericResponse<TaskDTO>> Create(TaskCreateRequestModel model)
        {
            try
            {
                if (_repTask.GetStatus(model.Status) is null)
                    throw new Exception(ResponseConstants.TaskStatusNotExists(model.Status));
                if (_repProj.Get(model.ProjectId) is null)
                    throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId));

                var createTask = await _repTask.Create(new Task
                {
                    Name = model.Name,
                    Description = model.Description,
                    StatusId = model.Status
                });
                var mapper = _mapper.Map<TaskDTO>(createTask);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<TaskDTO?> Get(Guid taskId)
        {
            try
            {
                var task = _repTask.Get(taskId) ?? throw new Exception(ResponseConstants.TaskNotExists(taskId));
                var mapper = _mapper.Map<TaskDTO?>(task);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<List<TaskDTO>> Get()
        {
            try
            {
                var findTasks = _repTask.Get();
                var mapper = _mapper.Map<List<TaskDTO>>(findTasks);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<TaskDTO>> Update(Guid taskId, TaskUpdateRequestModel model)
        {
            try
            {
                if (taskId == Guid.Empty) throw new Exception(ResponseConstants.TaskIdIsRequired);

                var findTask = _repTask.Get(taskId) ?? throw new Exception(ResponseConstants.TaskNotExists(taskId));

                if (model.Status.HasValue && _repTask.GetStatus(model.Status.Value) is null)
                    throw new Exception(ResponseConstants.TaskStatusNotExists(model.Status.Value));
                if (model.ProjectId.HasValue && _repProj.Get(model.ProjectId.Value) is null)
                    throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId.Value));

                findTask.Name = model.Name ?? findTask.Name;
                findTask.Description = model.Description ?? findTask.Description;
                findTask.StatusId = model.Status ?? findTask.StatusId;

                var updateTask = await _repTask.Update(findTask);
                var mapper = _mapper.Map<TaskDTO>(updateTask);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<TaskDTO>> Delete(Guid taskId)
        {
            try
            {
                if (taskId == Guid.Empty) throw new Exception(ResponseConstants.TaskIdIsRequired);

                var findTask = _repTask.Get(taskId) ?? throw new Exception(ResponseConstants.TaskNotExists(taskId));

                var deleteTask = _mapper.Map<TaskDTO>(await _repTask.Delete(findTask));
                return ManageResponse.Create(deleteTask);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Status
        public async Task<GenericResponse<TaskStatusDTO>> CreateStatus(TaskStatusCreateRequest model)
        {
            try
            {
                if (_repTask.GetStatus(model.Name) is not null)
                    throw new Exception(ResponseConstants.TaskStatusCreatedPreviously);

                var createTaskStatus = await _repTask.CreateStatus(new TasksStatus()
                {
                    Name = model.Name,
                    Description = model.Description,
                    BackgroundColor = model.BackgroundColor,
                    NameColor = model.NameColor
                });
                var mapper = _mapper.Map<TaskStatusDTO>(createTaskStatus);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<TaskStatusDTO?> GetStatus(int taskStatusId)
        {
            try
            {
                var findTaskStatus = _repTask.GetStatus(taskStatusId) ??
                                     throw new Exception(ResponseConstants.TaskStatusNotExists(taskStatusId));
                var mapper = _mapper.Map<TaskStatusDTO?>(findTaskStatus);

                return ManageResponse.Create(mapper);
                ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<TaskStatusDTO>> UpdateStatus(int taskStatusId,
            TaskStatusUpdateRequest model)
        {
            try
            {
                var findTaskStatus = _repTask.GetStatus(taskStatusId) ??
                                     throw new Exception(ResponseConstants.TaskStatusNotExists(taskStatusId));

                findTaskStatus.Name = model.Name ?? findTaskStatus.Name;
                findTaskStatus.Description = model.Description ?? findTaskStatus.Description;
                findTaskStatus.NameColor = model.NameColor ?? findTaskStatus.NameColor;
                findTaskStatus.BackgroundColor = model.BackgroundColor ?? findTaskStatus.BackgroundColor;

                var updateTaskStatus = await _repTask.UpdateStatus(findTaskStatus);
                var mapper = _mapper.Map<TaskStatusDTO>(updateTaskStatus);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<bool>> DeleteStatus(int taskStatusId)
        {
            try
            {
                var findTaskStatus = _repTask.GetStatus(taskStatusId) ??
                                     throw new Exception(ResponseConstants.TaskStatusNotExists(taskStatusId));

                var deleteTaskStatus = await _repTask.DeleteStatus(findTaskStatus);
                return ManageResponse.Create(deleteTaskStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}