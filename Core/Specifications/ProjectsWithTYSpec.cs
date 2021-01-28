using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProjectsWithTYSpec : BaseSpecification<Project>
    {
        public ProjectsWithTYSpec(int? typeId, int? yearId) : base(x => 
            (!typeId.HasValue || x.ProjectTypeId ==typeId) && (!yearId.HasValue || x.ProjectYearId == yearId)
            )
        {
            AddInclude(x => x.ProjectType);
            AddInclude(x => x.ProjectYear);
            // AddOrderBy(x => x.Description.Length);
        }

        public ProjectsWithTYSpec(int id) : base(p => p.Id ==id)
        {
            AddInclude(x => x.ProjectType);
            AddInclude(x => x.ProjectYear);
        }
    }
}