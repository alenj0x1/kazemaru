using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class ProjectRepository(KazemarudbContext db) : IProjectRepository
  {
    private readonly KazemarudbContext _db = db;

    public async Task<Project> CreateProject(Project project)
    {
      try
      {
        await _db.Projects.AddAsync(project);
        await _db.SaveChangesAsync();

        return project;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Project? GetProject(Guid projectId)
    {
      try
      {
        return _db.Projects.FirstOrDefault(proj => proj.Projectid == projectId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Project? GetProject(string projectName)
    {
      try
      {
        return _db.Projects.FirstOrDefault(proj => proj.Name == projectName);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Project> GetProjects()
    {
      try
      {
        return [.. _db.Projects];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Project?> UpdateProject(Project project)
    {
      try
      {
        _db.Projects.Update(project);
        await _db.SaveChangesAsync();

        return project;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteProject(Project project)
    {
      try
      {
        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    // Status
    public async Task<Projectstatus> CreateProjectStatus(Projectstatus projectStatus)
    {
      try
      {
        await _db.Projectstatuses.AddAsync(projectStatus);
        await _db.SaveChangesAsync();
        
        return projectStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Projectstatus? GetProjectStatus(int projectStatusId)
    {
      try
      {
        return _db.Projectstatuses.FirstOrDefault(pst => pst.Projectstatusid == projectStatusId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Projectstatus? GetProjectStatus(string projectStatusName)
    {
      try
      {
        return _db.Projectstatuses.FirstOrDefault(pst => pst.Name == projectStatusName);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Projectstatus?> UpdateProjectStatus(Projectstatus projectStatus)
    {
      try
      {
        _db.Projectstatuses.Update(projectStatus);
        await _db.SaveChangesAsync();

        return projectStatus;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteProjectStatus(Projectstatus projectStatus)
    {
      try
      {
        _db.Projectstatuses.Remove(projectStatus);
        await _db.SaveChangesAsync();

        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
