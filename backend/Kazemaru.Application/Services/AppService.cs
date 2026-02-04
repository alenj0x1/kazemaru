using AutoMapper;
using Kazemaru.Application.Helpers;
using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Responses;
using Kazemaru.Infrastructure.Persistence.Postgres.Repositories;

namespace Kazemaru.Application.Services;

public class AppService(AppRepository appRepository, IMapper mapper) : IAppService
{
    private readonly AppRepository _repApp = appRepository;
    private readonly IMapper _mapper = mapper;

    public GenericResponse<AppInfoDto> Info()
    {
        try
        {
            AppInfoDto crtAppInfo = new()
            {
                Tags = _mapper.Map<List<TagDto>>(_repApp.GetTags()),
                ProjectStatuses = _mapper.Map<List<ProjectStatusDto>>(_repApp.GetProjectStatuses()),
                TaskStatuses = _mapper.Map<List<TaskStatusDto>>(_repApp.GetTaskStatuses())
            };

            return ManageResponse.Create(crtAppInfo);
        }
        catch
        {
            throw;
        }
    }
}