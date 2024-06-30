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
      #endregion Project
    }
  }
}
