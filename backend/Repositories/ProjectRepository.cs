using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories
{
    public class ProjectRepository(KazemaruDbContext db) : IProjectRepository
    {
        private readonly KazemaruDbContext _db = db;

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

        public Guid? FindIfExistsProject(Guid projectId)
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

        public Project? GetProject(Guid projectId)
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
        public async Task<ProjectsStatus> CreateProjectStatus(ProjectsStatus projectStatus)
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

        public int? FindIfExistsProjectStatus(int projectStatusId)
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

        public ProjectsStatus? GetProjectStatus(int projectStatusId)
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

        public ProjectsStatus? GetProjectStatus(string projectStatusName)
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

        public async Task<ProjectsStatus?> UpdateProjectStatus(ProjectsStatus projectStatus)
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

        public async Task<bool> DeleteProjectStatus(ProjectsStatus projectStatus)
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