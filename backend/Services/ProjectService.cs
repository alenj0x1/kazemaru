using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models.Request.Project;
using backend.Repositories.Contract;
using backend.Services.Contract;

namespace backend.Services
{
  public class ProjectService(IProjectRepository repProj, ITaskRepository repTask, IMapper mapper) : IProjectService
  {
    private readonly IProjectRepository _repProj = repProj;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IMapper _mapper = mapper;

    public async Task<ProjectDTO> CreateProject(ProjectCreateRequestModel model)
    {
      try
      {
        if (_repProj.GetProject(model.Name) is not null) throw new Exception("The project was previously created");
        if (model.Name.Length > 50) throw new Exception("The project name length is longer than allowed.");
        if (model.Status != 1 && _repProj.GetProjectStatus(model.Status) is null) throw new Exception($"The project status with ID: '{model.Status}' does not exist.");

        Project crtProject = await _repProj.CreateProject(model);
        ProjectDTO mpProject = _mapper.Map<ProjectDTO>(crtProject);
        
        mpProject.Status = _mapper.Map<ProjectStatusDTO>(_repProj.GetProjectStatus(crtProject.Statusid));

        return mpProject;
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
        Project? findProj = _repProj.GetProject(projectId) ?? throw new Exception($"The project with ID '{projectId}' does not exist.");
        ProjectDTO mappedProj = _mapper.Map<ProjectDTO>(findProj);

        return mappedProj;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<ProjectDTO> GetProjects()
    {
      try
      {
        List<Project> projs = _repProj.GetProjects();
        List<ProjectDTO> mappedProjs = [];

        foreach (Project proj in projs)
        {
          ProjectDTO mappedProj = _mapper.Map<ProjectDTO>(proj);
          mappedProj.Status = _mapper.Map<ProjectStatusDTO>(_repProj.GetProjectStatus(proj.Statusid));

          mappedProjs.Add(_mapper.Map<ProjectDTO>(proj));
        }

        return mappedProjs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ProjectDTO> UpdateProject(ProjectUpdateRequestModel model)
    {
      try
      {
        if (model.ProjectId == Guid.Empty) throw new Exception("The project id is a required field");
        if (_repProj.GetProject(model.ProjectId) is null) throw new Exception($"The project with ID '{model.ProjectId}' does not exist.");
        if (model.Name is not null && model.Name.Length > 50) throw new Exception("The project name length is longer than allowed.");
        if (model.Status.HasValue && _repProj.GetProjectStatus(model.Status.Value) is null) throw new Exception($"The project status with ID: '{model.Status}' does not exist.");

        Project? updProj = await _repProj.UpdateProject(model) ?? throw new Exception("The project was not updated correctly");
        ProjectDTO mappedUpdProj = _mapper.Map<ProjectDTO>(updProj);

        return mappedUpdProj;
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
        if (projectId == Guid.Empty) throw new Exception("The project id is a required field");
        if (_repProj.GetProject(projectId) is null) throw new Exception($"The project with ID '{projectId}' does not exist.");
        if (_repTask.GetTasks(projectId).Count != 0) throw new Exception("You cannot delete a project that is linked to tasks.");

        return await _repProj.DeleteProject(projectId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    public async Task<ProjectStatusDTO> CreateProjectStatus(ProjectStatusCreateRequestModel model)
    {
      try
      {
        if (_repProj.GetProjectStatus(model.Name) is not null) throw new Exception("The project status was previously created");
        if (model.Name.Length > 30) throw new Exception("The project status name length is longer than allowed.");
        if (model.Description is not null && model.Description.Length > 50) throw new Exception("The project status content length is longer than allowed.");

        return _mapper.Map<ProjectStatusDTO>(await _repProj.CreateProjectStatus(model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public ProjectStatusDTO GetProjectStatus(int projectStatusId)
    {
      try
      {
        Projectstatus? projStatus = _repProj.GetProjectStatus(projectStatusId) ?? throw new Exception($"The project status with id: '{projectStatusId}' does not exist.");
        return _mapper.Map<ProjectStatusDTO>(projStatus); ;
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
        if (_repProj.GetProjectStatus(model.Projectstatusid) is null) throw new Exception("The project status has not been created");

        Projectstatus? updatedProjStatus = await _repProj.UpdateProjectStatus(model) ?? throw new Exception("The project status was not updated correctly");

        return _mapper.Map<ProjectStatusDTO>(updatedProjStatus);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteProjectStatus(int projectStatusId)
    {
      try
      {
        if (_repProj.GetProjectStatus(projectStatusId) is null) throw new Exception("The project status has not been created");

        return await _repProj.DeleteProjectStatus(projectStatusId);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
