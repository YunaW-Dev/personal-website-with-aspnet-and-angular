using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyContext _context;

        public ProjectRepository(MyContext context)
        {
            _context = context;

        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
            .Include(p => p.ProjectType)
            .Include(p => p.ProjectYear).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Project>> GetProjectsAsync()
        {
            return await _context.Projects
            .Include(p => p.ProjectType)
            .Include(p => p.ProjectYear).ToListAsync();
        }

        public async Task<IReadOnlyList<ProjectType>> GetProjectTypesAsync()
        {
            return await _context.ProjectTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProjectYear>> GetProjectYearsAsync()
        {
            return await _context.ProjectYears.ToListAsync();
        }
    }
}