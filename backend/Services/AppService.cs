using AutoMapper;
using backend.DTO;
using backend.Repositories.Contract;
using backend.Services.Contract;

namespace backend.Services
{
  public class AppService(IAppRepository appRepository, IMapper mapper) : IAppService
  {
    private readonly IAppRepository _repApp = appRepository;
    private readonly IMapper _mapper = mapper;

    public AppInfoDTO Info()
    {
			try
			{
        AppInfoDTO crtAppInfo = new()
        {
          Tags = _mapper.Map<List<TagDTO>>(_repApp.GetTags()),
          ProjectStatuses = _mapper.Map<List<ProjectStatusDTO>>(_repApp.GetProjectStatuses()),
          TaskStatuses = _mapper.Map<List<TaskStatusDTO>>(_repApp.GetTaskStatuses())
        };

        return crtAppInfo;
			}
			catch (Exception)
			{
				throw;
			}
    }
  }
}
