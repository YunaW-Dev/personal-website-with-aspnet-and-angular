using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IGenericRepository<Project> _projectsRepo;
        private readonly IGenericRepository<ProjectType> _projectTypeRepo;
        private readonly IGenericRepository<ProjectYear> _projectYearRepo;
        private readonly IMapper _mapper;
        public ProjectsController(IGenericRepository<Project> projectsRepo,
        IGenericRepository<ProjectType> projectTypeRepo,
        IGenericRepository<ProjectYear> projectYearRepo,
        IMapper mapper)
        {
            _projectsRepo = projectsRepo;
            _projectTypeRepo = projectTypeRepo;
            _projectYearRepo = projectYearRepo;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Project2ReturnDto>>> GetProjects(int? typeId, int? yearId)
    {
        var spec = new ProjectsWithTYSpec(typeId, yearId);
        var projects = await _projectsRepo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<Project>, IReadOnlyList<Project2ReturnDto>>(projects));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project2ReturnDto>> GetProject(int id)
    {
        var spec = new ProjectsWithTYSpec(id);
        var project = await _projectsRepo.GetEntityWithSpec(spec);
        return _mapper.Map<Project, Project2ReturnDto>(project);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProjectType>>> GetProjectTypes()
    {
        return Ok(await _projectTypeRepo.ListAllAsync());
    }

    [HttpGet("years")]
    public async Task<ActionResult<IReadOnlyList<ProjectYear>>> GetProjectYears()
    {
        return Ok(await _projectYearRepo.ListAllAsync());
    }

}
}