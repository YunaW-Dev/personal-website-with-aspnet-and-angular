using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
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

        public ProjectsController(IGenericRepository<Project> projectsRepo,
        IGenericRepository<ProjectType> projectTypeRepo,
        IGenericRepository<ProjectYear> projectYearRepo)
        {
            _projectsRepo = projectsRepo;
            _projectTypeRepo = projectTypeRepo;
            _projectYearRepo = projectYearRepo;
        }

    [HttpGet]
    public async Task<ActionResult<List<Project2ReturnDto>>> GetProjects()
    {
        var spec = new ProjectsWithTYSpec();
        var projects = await _projectsRepo.ListAsync(spec);
        return projects.Select(project => new Project2ReturnDto{
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            PictureUrl = project.PictureUrl,
            ProjectType = project.ProjectType.Name,
            ProjectYear = project.ProjectYear.YearNumber  
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project2ReturnDto>> GetProject(int id)
    {
        var spec = new ProjectsWithTYSpec(id);
        var project = await _projectsRepo.GetEntityWithSpec(spec);
        return new Project2ReturnDto{
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            PictureUrl = project.PictureUrl,
            ProjectType = project.ProjectType.Name,
            ProjectYear = project.ProjectYear.YearNumber  
        };
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