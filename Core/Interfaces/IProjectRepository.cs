using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProjectRepository
    {
         Task<Project> GetProjectByIdAsync(int id);
         Task<IReadOnlyList<Project>> GetProjectsAsync();
    }
}