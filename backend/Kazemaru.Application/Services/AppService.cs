using AutoMapper;
using backend.DTO;
using backend.Helpers;
using backend.Kazemaru.Application.Interfaces.Services;
using backend.Kazemaru.Application.Models.Responses;
using backend.Repositories;
using backend.Repositories.Contract;

namespace backend.Kazemaru.Application.Services
{
    public class AppService(AppRepository appRepository, IMapper mapper) : IAppService
    {
        private readonly AppRepository _repApp = appRepository;
        private readonly IMapper _mapper = mapper;

        public GenericResponse<AppInfoDTO> Info()
        {
            try
            {
                AppInfoDTO crtAppInfo = new()
                {
                    Tags = _mapper.Map<List<TagDTO>>(_repApp.GetTags()),
                    ProjectStatuses = _mapper.Map<List<ProjectStatusDTO>>(_repApp.GetProjectStatuses()),
                    TaskStatuses = _mapper.Map<List<TaskStatusDTO>>(_repApp.GetTaskStatuses())
                };

                return ManageResponse.Create(crtAppInfo);
            }
            catch
            {
                throw;
            }
        }
    }
}