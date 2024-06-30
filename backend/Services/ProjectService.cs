﻿using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models.Request.Project;
using backend.Repositories.Contract;
using backend.Services.Contract;

namespace backend.Services
{
  public class ProjectService(KazemarudbContext db, IProjectRepository repProj, ITaskRepository repTask, IMapper mapper) : IProjectService
  {
    private readonly KazemarudbContext _db = db;
    private readonly IProjectRepository _repProj = repProj;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IMapper _mapper = mapper;

    private readonly string[] _reservedProjStatus = ["all", "unstarted", "starting", "in_progress", "ended"];

    // Project
    public async Task<ProjectDTO> CreateProject(ProjectCreateRequestModel model)
    {
      try
      {
        if (_repProj.GetProject(_db, model.Name) is not null) throw new Exception("The project was previously created");
        if (model.Name.Length > 50) throw new Exception("The project name length is longer than allowed.");

        if (model.Status != 1 && _repProj.GetProjectStatus(_db, Convert.ToInt32(model.Status)) is null) throw new Exception($"The project status with ID: '{model.Status}' does not exist.");

        return _mapper.Map<ProjectDTO>(await _repProj.CreateProject(_db, model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public ProjectDTO GetProject(Guid projectId)
    {
      try
      {
        Project? findProj = _repProj.GetProject(_db, projectId) ?? throw new Exception($"The project with ID '{projectId}' does not exist.");
        return _mapper.Map<ProjectDTO>(findProj);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public ProjectDTO GetProject(string projectName)
    {
      try
      {
        Project? findProj = _repProj.GetProject(_db, projectName) ?? throw new Exception($"The project with name '{projectName}' does not exist.");
        return _mapper.Map<ProjectDTO>(findProj);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<ProjectDTO> GetProjects()
    {
      return _mapper.Map<List<ProjectDTO>>(_repProj.GetProjects(_db));
    }

    public async Task<ProjectDTO> UpdateProject(ProjectUpdateRequestModel model)
    {
      try
      {
        if (_repProj.GetProject(_db, model.ProjectId) is null) throw new Exception($"The project with ID '{model.ProjectId}' does not exist.");
        if (model.Name is not null && model.Name.Length > 50) throw new Exception("The project name length is longer than allowed.");

        if (model.Status is not null && _repProj.GetProjectStatus(_db, Convert.ToInt32(model.Status)) is null) throw new Exception($"The project status with ID: '{model.Status}' does not exist.");

        Project? updProj = await _repProj.UpdateProject(_db, model) ?? throw new Exception("The project was not updated correctly");
        return _mapper.Map<ProjectDTO>(updProj);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteProject(Guid projectId)
    {
      try
      {
        if (_repProj.GetProject(_db, projectId) is null) throw new Exception($"The project with ID '{projectId}' does not exist.");
        if (_repTask.GetTasks(_db, projectId).Count != 0) throw new Exception("You cannot delete a project that is linked to tasks.");

        return await _repProj.DeleteProject(_db, projectId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Project status
    public async Task<ProjectStatusDTO> CreateProjectStatus(ProjectStatusCreateRequestModel model)
    {
      try
      {
        if (_reservedProjStatus.Where(projStatus => projStatus == model.Name).Any()) throw new Exception("You cannot create a new project status name that is reserved: all, unstarted, started, in_progress, ended.");
        if (_repProj.GetProjectStatus(_db, model.Name) is not null) throw new Exception("The project status was previously created");
        if (model.Name.Length > 30) throw new Exception("The project status name length is longer than allowed.");
        if (model.Content is not null && model.Content.Length > 50) throw new Exception("The project status content length is longer than allowed.");

        Projectstatus projStatus = await _repProj.CreateProjectStatus(_db, model);
        ProjectStatusDTO mappedProjStatus = _mapper.Map<ProjectStatusDTO>(projStatus);

        return mappedProjStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public ProjectStatusDTO GetProjectStatus(string statusName)
    {
      try
      {
        Projectstatus? projStatus = _repProj.GetProjectStatus(_db, statusName) ?? throw new Exception($"The project status with name '{statusName}' does not exist.");
        ProjectStatusDTO mappedProjStatus = _mapper.Map<ProjectStatusDTO>(projStatus);

        return mappedProjStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<ProjectStatusDTO> GetAllProjectStatus()
    {
      try
      {
        List<Projectstatus> listProjStatus = _repProj.GetAllProjectStatus(db);
        List<ProjectStatusDTO> listMappedProjStatus = _mapper.Map<List<ProjectStatusDTO>>(listProjStatus);

        return listMappedProjStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ProjectStatusDTO> UpdateProjectStatus(ProjectStatusUpdateRequestModel model)
    {
      try
      {
        if (_reservedProjStatus.Where(projStatus => projStatus == model.Name).Any()) throw new Exception("You cannot update to a new project status name that is reserved: all, unstarted, started, in_progress, ended.");
        if (_repProj.GetProjectStatus(_db, model.Name) is null) throw new Exception("The project status has not been created");

        Projectstatus? updatedProjStatus = await _repProj.UpdateProjectStatus(db, model) ?? throw new Exception("The project status was not updated correctly");

        return _mapper.Map<ProjectStatusDTO>(updatedProjStatus);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteProjectStatus(string statusName)
    {
      try
      {
        if (_reservedProjStatus.Where(projStatus => projStatus == statusName).Any()) throw new Exception("You cannot update to a new project status name that is reserved: all, unstarted, started, in_progress, ended.");
        if (_repProj.GetProjectStatus(_db, statusName) is null) throw new Exception("The project status has not been created");
        if (_repProj.GetProjects(_db).Where(proj => _repProj.GetProjectStatus(_db, Convert.ToInt32(proj.Status))?.Name == statusName).Any()) throw new Exception("You cannot delete the project status because it is linked to a project.");

        return await _repProj.DeleteProjectStatus(_db, statusName);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}