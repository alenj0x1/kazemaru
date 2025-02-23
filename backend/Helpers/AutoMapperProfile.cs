using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Entity.Postgres;
using Task = backend.Entity.Postgres.Task;

namespace backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Project

            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<ProjectStatusDTO, Projectstatus>().ReverseMap();
            CreateMap<TagDTO, Projecttag>().ReverseMap();

            #endregion Project

            #region Task

            CreateMap<TaskDTO, Task>().ReverseMap();
            CreateMap<TaskStatusDTO, Taskstatus>().ReverseMap();

            #endregion Task

            #region Note

            CreateMap<NoteDTO, Note>().ReverseMap();
            CreateMap<TagDTO, Notetag>().ReverseMap();

            #endregion Note
            
            #region User
            CreateMap<UserDTO, User>().ReverseMap();
            #endregion User
        }
    }
}