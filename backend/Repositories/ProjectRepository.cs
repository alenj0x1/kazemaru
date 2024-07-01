using backend.Entity;
using backend.Models.Request.Project;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class ProjectRepository : IProjectRepository
  {
    // Project
    public async Task<Project> CreateProject(KazemarudbContext db, ProjectCreateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Project newProject = new()
        {
          Name = model.Name,
          Description = model.Description ?? null,
          Status = model.Status
        };

        await db.Projects.AddAsync(newProject);
        await db.SaveChangesAsync();

        await tx.CommitAsync();

        return newProject;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Project? GetProject(KazemarudbContext db, Guid projectId)
    {
      try
      {
        return db.Projects.Where(proj => proj.Projectid == projectId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Project? GetProject(KazemarudbContext db, string projectName)
    {
      try
      {
        return db.Projects.Where(proj => proj.Name == projectName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Project> GetProjects(KazemarudbContext db)
    {
      try
      {
        return [.. db.Projects];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Project?> UpdateProject(KazemarudbContext db, ProjectUpdateRequestModel model)
    {
      using var tx = db.Database.BeginTransaction();

      try
      {
        Project? proj = GetProject(db, model.ProjectId);

        if (proj is not null)
        {
          proj.Name = model.Name ?? proj.Name;
          proj.Description = model.Description ?? proj.Description;
          proj.Status = model.Status ?? proj.Status;

          db.Projects.Update(proj);
          await db.SaveChangesAsync();
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

    public async Task<bool> DeleteProject(KazemarudbContext db, Guid projectId)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Project? proj = GetProject(db, projectId);

        if (proj is not null)
        {
          db.Projects.Remove(proj);
          await db.SaveChangesAsync();
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

    // Project status
    public async Task<Projectstatus> CreateProjectStatus(KazemarudbContext db, ProjectStatusCreateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Projectstatus newProjStatus = new()
        {
          Name = model.Name,
          Content = model.Content,
        };

        await db.Projectstatuses.AddAsync(newProjStatus);
        await db.SaveChangesAsync();

        await tx.CommitAsync();
        return newProjStatus;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Projectstatus? GetProjectStatus(KazemarudbContext db, string statusName)
    {
      try
      {
        return db.Projectstatuses.Where(projSt => projSt.Name == statusName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Projectstatus? GetProjectStatus(KazemarudbContext db, int statusId)
    {
      try
      {
        return db.Projectstatuses.Where(projSt => projSt.Statusid == statusId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Projectstatus> GetAllProjectStatus(KazemarudbContext db)
    {
      try
      {
        return [.. db.Projectstatuses];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Projectstatus?> UpdateProjectStatus(KazemarudbContext db, ProjectStatusUpdateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Projectstatus? findProjStatus = GetProjectStatus(db, model.Name);

        if (findProjStatus is not null)
        {
          findProjStatus.Name = model.Name ?? findProjStatus.Name;
          findProjStatus.Content = model.Content ?? findProjStatus.Content;

          db.Projectstatuses.Update(findProjStatus);
          await db.SaveChangesAsync();
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

    public async Task<bool> DeleteProjectStatus(KazemarudbContext db, string statusName)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Projectstatus? findProjStatus = GetProjectStatus(db, statusName);

        if (findProjStatus is not null)
        {
          db.Projectstatuses.Remove(findProjStatus);
          await db.SaveChangesAsync();
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

    // Project tag
    public async Task<Projecttag> CreateProjectTag(KazemarudbContext db, ProjectTagCreateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Projecttag crtProjTag = new()
        {
          Projectid = model.ProjectId,
          Name = model.Name,
        };

        await db.Projecttags.AddAsync(crtProjTag);
        await db.SaveChangesAsync();
        
        await tx.CommitAsync();
        return crtProjTag;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Projecttag? GetProjectTag(KazemarudbContext db, Guid projectTagId)
    {
      try
      {
        return db.Projecttags.Where(projTag => projTag.Projecttagid == projectTagId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Projecttag? GetProjectTag(KazemarudbContext db, string projectTagName)
    {
      try
      {
        return db.Projecttags.Where(projTag => projTag.Name == projectTagName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Projecttag> GetProjectTags(KazemarudbContext db)
    {
      try
      {
        return [.. db.Projecttags];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Projecttag> GetProjectTags(KazemarudbContext db, Guid projectId)
    {
      try
      {
        return [.. db.Projecttags.Where(projTag => projTag.Projectid == projectId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Projecttag?> UpdateProjectTag(KazemarudbContext db, ProjectTagUpdateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Projecttag? updProjTag = GetProjectTag(db, model.ProjectTagId);

        if (updProjTag is not null)
        {
          updProjTag.Projectid = model.ProjectId ?? updProjTag.Projectid;
          updProjTag.Name = model.Name ?? updProjTag.Name;

          db.Projecttags.Update(updProjTag);
          await db.SaveChangesAsync();
        }

        await tx.CommitAsync();
        return updProjTag;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteProjectTag(KazemarudbContext db, Guid projectTagId)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Projecttag? delProjTag = GetProjectTag(db, projectTagId);

        if (delProjTag is not null)
        {
          db.Projecttags.Remove(delProjTag);
          await db.SaveChangesAsync();
          await tx.CommitAsync();

          return true;
        }

        return false;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }
  }
}
