using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Project, Project2ReturnDto>()
            .ForMember(d => d.ProjectType, o => o.MapFrom(s => s.ProjectType.Name))
            .ForMember(d => d.ProjectYear, o => o.MapFrom(s => s.ProjectYear.YearNumber))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProjectUrlResolver>());
        }
    }
}