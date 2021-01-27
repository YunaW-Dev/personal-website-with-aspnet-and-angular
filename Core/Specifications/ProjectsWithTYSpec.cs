using Core.Entities;

namespace Core.Specifications
{
    public class ProjectsWithTYSpec : BaseSpecification<Project>
    {
        public ProjectsWithTYSpec()
        {
            AddInclude(x => x.ProjectType);
            AddInclude(x => x.ProjectYear);
        }
    }
}