using backend.Controllers.Contract;
using backend.DTO;
using backend.Models;
using backend.Models.Request.Project;
using backend.Models.Request.Project.Status;
using backend.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase, IProjectsController
    {
        private readonly IProjectService _srvProj = projectService;

        [Authorize]
        [HttpPost]
        public async Task<GenericResponse<ProjectDTO>> CreateProject([FromBody] ProjectCreateRequestModel model)
        {
            try
            {
                return await _srvProj.Create(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("{projectId:guid}")]
        public GenericResponse<ProjectDTO?> GetProject(Guid projectId)
        {
            try
            {
                return _srvProj.Get(projectId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public GenericResponse<List<ProjectDTO>> GetProjects()
        {
            try
            {
                return _srvProj.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("{projectId:guid}")]
        public async Task<GenericResponse<ProjectDTO>> UpdateProject(Guid projectId,
            [FromBody] ProjectUpdateRequestModel model)
        {
            try
            {
                return await _srvProj.Update(projectId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete("{projectId:guid}")]
        public async Task<GenericResponse<ProjectDTO>> DeleteProject(Guid projectId)
        {
            try
            {
                return await _srvProj.Delete(projectId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Status
        [Authorize]
        [HttpPost("status")]
        public async Task<GenericResponse<ProjectStatusDTO>> CreateProjectStatus(
            [FromBody] ProjectStatusCreateRequestModel model)
        {
            try
            {
                return await _srvProj.CreateStatus(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("status/{projectStatusId:int}")]
        public async Task<GenericResponse<ProjectStatusDTO>> UpdateProjectStatus(int projectStatusId,
            [FromBody] ProjectStatusUpdateRequestModel model)
        {
            try
            {
                return await _srvProj.UpdateStatus(projectStatusId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete("status/{projectStatusId:int}")]
        public async Task<GenericResponse<bool>> DeleteProjectStatus(int projectStatusId)
        {
            try
            {
                return await _srvProj.DeleteStatus(projectStatusId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}