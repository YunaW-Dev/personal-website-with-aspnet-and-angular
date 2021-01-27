using System;
using System.Linq.Expressions;
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

        public ProjectsWithTYSpec(int id) : base(p => p.Id ==id)
        {
            AddInclude(x => x.ProjectType);
            AddInclude(x => x.ProjectYear);
        }
    }
}