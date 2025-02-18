using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories
{
    public class ProjectRepository(KazemaruDbContext db) : BaseRepository<Project>(db), IProjectRepository
    {
        private readonly KazemaruDbContext _db = db;

        public Guid? FindIfExists(Guid projectId)
        {
            try
            {
                return _db.Projects
                    .Where(prj => prj.ProjectId == projectId)
                    .Select(prj => prj.ProjectId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Project? Get(Guid projectId)
        {
            try
            {
                return _db.Projects.FirstOrDefault(proj => proj.ProjectId == projectId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Project? Get(string name)
        {
            try
            {
                return _db.Projects.FirstOrDefault(proj => proj.Name == name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Project> Get()
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

        // Status
        public async Task<ProjectsStatus> CreateStatus(ProjectsStatus projectStatus)
        {
            try
            {
                await _db.ProjectsStatuses.AddAsync(projectStatus);
                await _db.SaveChangesAsync();

                return projectStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public int? FindIfExistsStatus(int projectStatusId)
        {
            try
            {
                return _db.ProjectsStatuses
                    .Where(prjst => prjst.ProjectStatusId == projectStatusId)
                    .Select(prjst => prjst.ProjectStatusId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProjectsStatus? GetStatus(int projectStatusId)
        {
            try
            {
                return _db.ProjectsStatuses.FirstOrDefault(pst => pst.ProjectStatusId == projectStatusId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProjectsStatus? GetStatus(string projectStatusName)
        {
            try
            {
                return _db.ProjectsStatuses.FirstOrDefault(pst => pst.Name == projectStatusName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProjectsStatus?> UpdateStatus(ProjectsStatus projectStatus)
        {
            try
            {
                _db.ProjectsStatuses.Update(projectStatus);
                await _db.SaveChangesAsync();

                return projectStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteStatus(ProjectsStatus projectStatus)
        {
            try
            {
                _db.ProjectsStatuses.Remove(projectStatus);
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