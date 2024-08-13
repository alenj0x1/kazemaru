using backend.Entity;
using backend.Models.Request.Project;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class ProjectRepository(KazemarudbContext db) : IProjectRepository
  {
    private readonly KazemarudbContext _db = db;

    public async Task<Project> CreateProject(ProjectCreateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Project newProject = new()
        {
          Name = model.Name,
          Description = model.Description ?? null,
          Banner = model.Banner ?? null,
          Statusid = model.Status
        };

        await _db.Projects.AddAsync(newProject);
        await _db.SaveChangesAsync();

        await tx.CommitAsync();

        return newProject;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Project? GetProject(Guid projectId)
    {
      try
      {
        return _db.Projects.Where(proj => proj.Projectid == projectId).FirstOrDefault();
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
        return _db.Projects.Where(proj => proj.Name == projectName).FirstOrDefault();
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

    public async Task<Project?> UpdateProject(ProjectUpdateRequestModel model)
    {
      using var tx = _db.Database.BeginTransaction();

      try
      {
        Project? proj = GetProject(model.ProjectId);

        if (proj is not null)
        {
          proj.Name = model.Name ?? proj.Name;
          proj.Description = model.Description ?? proj.Description;
          proj.Banner = model.Banner ?? proj.Banner;
          proj.Statusid = model.Status ?? proj.Statusid;

          _db.Projects.Update(proj);
          await _db.SaveChangesAsync();
        }

        await tx.CommitAsync();

        return proj;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteProject(Guid projectId)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Project? proj = GetProject(projectId);

        if (proj is not null)
        {
          _db.Projects.Remove(proj);
          await _db.SaveChangesAsync();
        }

        await tx.CommitAsync();

        return true;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        return false;
      }
    }

    // Status
    public async Task<Projectstatus> CreateProjectStatus(ProjectStatusCreateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Projectstatus newProjStatus = new()
        {
          Name = model.Name,
          Description = model.Description,
        };

        await _db.Projectstatuses.AddAsync(newProjStatus);
        await _db.SaveChangesAsync();

        await tx.CommitAsync();
        return newProjStatus;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Projectstatus? GetProjectStatus(int projectStatusId)
    {
      try
      {
        return _db.Projectstatuses.Where(pst => pst.Projectstatusid == projectStatusId).FirstOrDefault();
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
        return _db.Projectstatuses.Where(pst => pst.Name == projectStatusName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Projectstatus?> UpdateProjectStatus(ProjectStatusUpdateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Projectstatus? findProjStatus = GetProjectStatus(model.Projectstatusid);

        if (findProjStatus is not null)
        {
          findProjStatus.Name = model.Name ?? findProjStatus.Name;
          findProjStatus.Description = model.Description ?? findProjStatus.Description;

          _db.Projectstatuses.Update(findProjStatus);
          await _db.SaveChangesAsync();
        }

        await tx.CommitAsync();

        return findProjStatus;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteProjectStatus(int projectStatusId)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Projectstatus? findProjStatus = GetProjectStatus(projectStatusId);

        if (findProjStatus is not null)
        {
          _db.Projectstatuses.Remove(findProjStatus);
          await _db.SaveChangesAsync();
          await tx.CommitAsync();
          return true;
        }

        await tx.RollbackAsync();

        return false;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        return false;
      }
    }
  }
}
