using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models;
using backend.Models.Request.Project;
using backend.Models.Request.Project.Status;
using backend.Repositories.Contract;
using backend.Services.Contract;
using backend.Tools;
using Exception = System.Exception;

namespace backend.Services
{
  public class ProjectService(IProjectRepository repProj, ITaskRepository repTask, IMapper mapper) : IProjectService
  {
    private readonly IProjectRepository _repProj = repProj;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IMapper _mapper = mapper;

    public async Task<GenericResponse<ProjectDTO>> CreateProject(ProjectCreateRequestModel model)
    {
      try
      {
        if (_repProj.GetProject(model.Name) is not null) throw new Exception(ResponseConstants.ProjectCreatedPreviously);
        if (model.Status != 1 && _repProj.GetProjectStatus(model.Status) is null) throw new Exception(ResponseConstants.ProjectStatusNotExists(model.Status));

        var createProject = await _repProj.CreateProject(new Project
        {
          Name = model.Name,
          Description = model.Description ?? null,
          Banner = model.Banner ?? null,
          Statusid = model.Status
        });
        var mapper = _mapper.Map<ProjectDTO>(createProject);
        
        mapper.Status = _mapper.Map<ProjectStatusDTO>(_repProj.GetProjectStatus(createProject.Statusid));

        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public GenericResponse<ProjectDTO?> GetProject(Guid projectId)
    {
      try
      {
        var findProject = _repProj.GetProject(projectId) ?? throw new Exception(ResponseConstants.ProjectNotExists(projectId));
        var mapper = _mapper.Map<ProjectDTO?>(findProject);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public GenericResponse<List<ProjectDTO>> GetProjects()
    {
      try
      {
        var findProjects = _repProj.GetProjects();
        
        List<ProjectDTO> mapped = [];
        foreach (var proj in findProjects)
        {
          var mappedProj = _mapper.Map<ProjectDTO>(proj);
          
          mappedProj.Status = _mapper.Map<ProjectStatusDTO>(_repProj.GetProjectStatus(proj.Statusid));
          mapped.Add(_mapper.Map<ProjectDTO>(proj));
        }

        return ManageResponse.Create(mapped);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<ProjectDTO>> UpdateProject(Guid projectId, ProjectUpdateRequestModel model)
    {
      try
      {
        if (projectId == Guid.Empty) throw new Exception(ResponseConstants.ProjectIdIsRequired);
        
        var findProject = _repProj.GetProject(projectId) ?? throw new Exception(ResponseConstants.ProjectNotExists(projectId));
        if (model.Status.HasValue && _repProj.GetProjectStatus(model.Status.Value) is null) throw new Exception(ResponseConstants.ProjectStatusNotExists(model.Status.Value));

        findProject.Name = model.Name ?? findProject.Name;
        findProject.Description = model.Description ?? findProject.Description;
        findProject.Banner = model.Banner ?? findProject.Banner;
        findProject.Statusid = model.Status ?? findProject.Statusid;
        
        var updateProject = await _repProj.UpdateProject(findProject);
        var mapper = _mapper.Map<ProjectDTO>(updateProject);

        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<bool>> DeleteProject(Guid projectId)
    {
      try
      {
        if (projectId == Guid.Empty) throw new Exception(ResponseConstants.ProjectIdIsRequired);
        
        var findProject = _repProj.GetProject(projectId) ?? throw new Exception(ResponseConstants.ProjectNotExists(projectId));
        if (_repTask.GetTasks(projectId).Count != 0) throw new Exception(ResponseConstants.ProjectLinkedToTasks);

        var deleteProject = await _repProj.DeleteProject(findProject);
        return ManageResponse.Create(deleteProject);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Status
    public async Task<GenericResponse<ProjectStatusDTO>> CreateProjectStatus(ProjectStatusCreateRequestModel model)
    {
      try
      {
        if (_repProj.GetProjectStatus(model.Name) is not null) throw new Exception(ResponseConstants.ProjectStatusCreatedPreviously);
        if (model.Description is not null && model.Description.Length > 50) throw new Exception(ResponseConstants.ProjectStatusDescriptionIsLongerThanAllowed);

        var createProjectStatus = await _repProj.CreateProjectStatus(new Projectstatus
        {
          Name = model.Name,
          Description = model.Description,
          Namecolor = model.NameColor,
          Backgroundcolor = model.BackgroundColor
        });
        var mapper = _mapper.Map<ProjectStatusDTO>(createProjectStatus);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public GenericResponse<ProjectStatusDTO?> GetProjectStatus(int projectStatusId)
    {
      try
      {
        var findProjectStatus = _repProj.GetProjectStatus(projectStatusId) ?? throw new Exception(ResponseConstants.ProjectStatusNotExists(projectStatusId));
        var mapper = _mapper.Map<ProjectStatusDTO?>(findProjectStatus);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<ProjectStatusDTO>> UpdateProjectStatus(int projectStatusId, ProjectStatusUpdateRequestModel model)
    {
      try
      {
        var findProjectStatus = _repProj.GetProjectStatus(projectStatusId) ?? throw new Exception(ResponseConstants.ProjectStatusNotExists(projectStatusId));
        
        findProjectStatus.Name = model.Name ?? findProjectStatus.Name;
        findProjectStatus.Description = model.Description ?? findProjectStatus.Description;
        findProjectStatus.Namecolor = model.NameColor ?? findProjectStatus.Namecolor;
        findProjectStatus.Backgroundcolor = model.BackgroundColor ?? findProjectStatus.Backgroundcolor;
        
        var updateProjectStatus = await _repProj.UpdateProjectStatus(findProjectStatus);
        var mapper = _mapper.Map<ProjectStatusDTO>(updateProjectStatus);
        
        return ManageResponse.Create(mapper);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<GenericResponse<bool>> DeleteProjectStatus(int projectStatusId)
    {
      try
      {
        var findProjectStatus = _repProj.GetProjectStatus(projectStatusId) ?? throw new Exception("The project status has not been created");
        var deleteProjectStatus = await _repProj.DeleteProjectStatus(findProjectStatus);
        
        return ManageResponse.Create(deleteProjectStatus);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
