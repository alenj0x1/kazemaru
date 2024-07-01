using AutoMapper;
using backend.DTO;
using backend.Entity;

namespace backend.Tools
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      #region Project
      CreateMap<ProjectDTO, Project>().ReverseMap();
      CreateMap<ProjectStatusDTO, Projectstatus>().ReverseMap();
      CreateMap<ProjectTagDTO, Projecttag>().ReverseMap();
      #endregion Project

      #region Task
      CreateMap<TaskDTO, Entity.Task>().ReverseMap();
      #endregion Task

      #region Note
      CreateMap<NoteDTO, Note>().ReverseMap();
      CreateMap<NoteTagDTO, Notetag>().ReverseMap();
      #endregion Note
    }
  }
}
