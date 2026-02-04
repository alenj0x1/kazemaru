using AutoMapper;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Domain.Entities;
using Task = Kazemaru.Domain.Entities.Task;

namespace Kazemaru.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Project

            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<ProjectStatusDto, ProjectsStatus>().ReverseMap();
            CreateMap<TagDto, ProjectsTag>().ReverseMap();

            #endregion Project

            #region Task

            CreateMap<TaskDto, Task>().ReverseMap();
            CreateMap<TaskStatusDto, TasksStatus>().ReverseMap();

            #endregion Task

            #region Note

            CreateMap<NoteDto, Note>().ReverseMap();
            CreateMap<TagDto, NotesTag>().ReverseMap();

            #endregion Note
            
            #region User
            CreateMap<UserDto, User>().ReverseMap();
            #endregion User
        }
    }
}