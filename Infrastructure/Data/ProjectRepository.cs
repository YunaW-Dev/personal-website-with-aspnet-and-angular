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
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IReadOnlyList<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}