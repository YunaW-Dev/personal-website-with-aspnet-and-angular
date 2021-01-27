using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public async Task<ActionResult<List<Project>>> GetProjects()
    {
        var spec = new ProjectsWithTYSpec();
        var projects = await _projectsRepo.ListAsync(spec);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        return await _projectsRepo.GetByIdAsync(id);
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