using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProjectUrlResolver : IValueResolver<Project, Project2ReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProjectUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Project source, Project2ReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)){
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}