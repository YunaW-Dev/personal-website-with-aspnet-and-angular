using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _repo;
        public ProjectsController(IProjectRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var projects = await _repo.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            return await _repo.GetProjectByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProjectType>>> GetProjectTypes()
        {
            return Ok(await _repo.GetProjectTypesAsync());
        }

        [HttpGet("years")]
        public async Task<ActionResult<IReadOnlyList<ProjectYear>>> GetProjectYears()
        {
            return Ok(await _repo.GetProjectYearsAsync());
        }




    }
}