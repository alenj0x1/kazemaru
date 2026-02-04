using System.Security.Claims;
using AutoMapper;
using Kazemaru.Application.Helpers;
using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Requests.Project;
using Kazemaru.Application.Models.Requests.Project.Status;
using Kazemaru.Application.Models.Responses;
using Kazemaru.Domain.Entities;
using Kazemaru.Domain.Exceptions;
using Kazemaru.Infrastructure.Persistence.Postgres.Repositories;
using Kazemaru.Shared;

namespace Kazemaru.Application.Services;

public class ProjectService(ProjectRepository repProj, TaskRepository repTask, IMapper mapper) : IProjectService
{
    private readonly ProjectRepository _repProj = repProj;
    private readonly TaskRepository _repTask = repTask;
    private readonly IMapper _mapper = mapper;

    public async Task<GenericResponse<ProjectDto>> Create(ProjectCreateRequestModel model, Claim userId)
    {
        try
        {
            if (_repProj.Get(model.Name) is not null)
                throw new Exception(ResponseConstants.ProjectCreatedPreviously);
            if (model.Status != 1 && _repProj.GetStatus(model.Status) is null)
                throw new Exception(ResponseConstants.ProjectStatusNotExists(model.Status));

            var ownerId = Parser.ToGuid(userId.Value) ??
                          throw new UnauthorizedAccessException(ResponseConstants.UserIdentityNotFound);

            var createProject = await _repProj.Create(new Project
            {
                Name = model.Name,
                Description = model.Description ?? null,
                Banner = model.Banner ?? null,
                StatusId = model.Status,
                OwnerId = ownerId,
            });
            var mapper = _mapper.Map<ProjectDto>(createProject);

            mapper.Status = _mapper.Map<ProjectStatusDto>(_repProj.GetStatus(createProject.StatusId));

            return ManageResponse.Create(mapper);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public GenericResponse<ProjectDto?> Get(Guid projectId)
    {
        try
        {
            var findProject = _repProj.Get(projectId) ??
                              throw new BadRequestException(ResponseConstants.ProjectNotExists(projectId));
            var mapper = _mapper.Map<ProjectDto?>(findProject);
            if (mapper is not null)
            {
                mapper.Status = _mapper.Map<ProjectStatusDto>(_repProj.GetStatus(findProject.StatusId));
            }

            return ManageResponse.Create(mapper);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public GenericResponse<List<ProjectDto>> Get()
    {
        try
        {
            var findProjects = _repProj.Get();

            List<ProjectDto> mapped = [];
            foreach (var proj in findProjects)
            {
                var mappedProj = _mapper.Map<ProjectDto>(proj);

                mappedProj.Status = _mapper.Map<ProjectStatusDto>(_repProj.GetStatus(proj.StatusId));
                mapped.Add(_mapper.Map<ProjectDto>(proj));
            }

            return ManageResponse.Create(mapped);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GenericResponse<ProjectDto>> Update(Guid projectId, ProjectUpdateRequestModel model)
    {
        try
        {
            if (projectId == Guid.Empty) throw new Exception(ResponseConstants.ProjectIdIsRequired);

            var findProject = _repProj.Get(projectId) ??
                              throw new Exception(ResponseConstants.ProjectNotExists(projectId));
            if (model.Status.HasValue && _repProj.GetStatus(model.Status.Value) is null)
                throw new Exception(ResponseConstants.ProjectStatusNotExists(model.Status.Value));

            findProject.Name = model.Name ?? findProject.Name;
            findProject.Description = model.Description ?? findProject.Description;
            findProject.Banner = model.Banner ?? findProject.Banner;
            findProject.StatusId = model.Status ?? findProject.StatusId;

            var updateProject = await _repProj.Update(findProject);
            var mapper = _mapper.Map<ProjectDto>(updateProject);

            return ManageResponse.Create(mapper);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GenericResponse<ProjectDto>> Delete(Guid projectId)
    {
        try
        {
            if (projectId == Guid.Empty) throw new Exception(ResponseConstants.ProjectIdIsRequired);

            var findProject = _repProj.Get(projectId) ??
                              throw new Exception(ResponseConstants.ProjectNotExists(projectId));
            if (_repTask.GetByProject(projectId).Count != 0)
                throw new Exception(ResponseConstants.ProjectLinkedToTasks);

            var deleteProject = _mapper.Map<ProjectDto>(await _repProj.Delete(findProject));
            return ManageResponse.Create(deleteProject);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // Status
    public async Task<GenericResponse<ProjectStatusDto>> CreateStatus(ProjectStatusCreateRequestModel model)
    {
        try
        {
            if (_repProj.GetStatus(model.Name) is not null)
                throw new Exception(ResponseConstants.ProjectStatusCreatedPreviously);
            if (model.Description is not null && model.Description.Length > 50)
                throw new Exception(ResponseConstants.ProjectStatusDescriptionIsLongerThanAllowed);

            var createProjectStatus = await _repProj.CreateStatus(new ProjectsStatus
            {
                Name = model.Name,
                Description = model.Description,
                NameColor = model.NameColor,
                BackgroundColor = model.BackgroundColor
            });
            var mapper = _mapper.Map<ProjectStatusDto>(createProjectStatus);

            return ManageResponse.Create(mapper);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public GenericResponse<ProjectStatusDto?> GetStatus(int projectStatusId)
    {
        try
        {
            var findProjectStatus = _repProj.GetStatus(projectStatusId) ??
                                    throw new Exception(ResponseConstants.ProjectStatusNotExists(projectStatusId));
            var mapper = _mapper.Map<ProjectStatusDto?>(findProjectStatus);

            return ManageResponse.Create(mapper);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GenericResponse<ProjectStatusDto>> UpdateStatus(int projectStatusId,
        ProjectStatusUpdateRequestModel model)
    {
        try
        {
            var findProjectStatus = _repProj.GetStatus(projectStatusId) ??
                                    throw new Exception(ResponseConstants.ProjectStatusNotExists(projectStatusId));

            findProjectStatus.Name = model.Name ?? findProjectStatus.Name;
            findProjectStatus.Description = model.Description ?? findProjectStatus.Description;
            findProjectStatus.NameColor = model.NameColor ?? findProjectStatus.NameColor;
            findProjectStatus.BackgroundColor = model.BackgroundColor ?? findProjectStatus.BackgroundColor;

            var updateProjectStatus = await _repProj.UpdateStatus(findProjectStatus);
            var mapper = _mapper.Map<ProjectStatusDto>(updateProjectStatus);

            return ManageResponse.Create(mapper);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GenericResponse<bool>> DeleteStatus(int projectStatusId)
    {
        try
        {
            var findProjectStatus = _repProj.GetStatus(projectStatusId) ??
                                    throw new Exception(ResponseConstants.ProjectStatusNotExists(projectStatusId));
            var deleteProjectStatus = await _repProj.DeleteStatus(findProjectStatus);

            return ManageResponse.Create(deleteProjectStatus);
        }
        catch (Exception)
        {
            throw;
        }
    }
}