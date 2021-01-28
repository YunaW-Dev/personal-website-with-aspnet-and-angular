using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> dbSelectCriteria)
        {
            DbSelectCriteria = dbSelectCriteria;
        }

        public Expression<Func<T, bool>> DbSelectCriteria {get;}

        public List<Expression<Func<T, object>>> Includes {get; } = 
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression){
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression){
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression){
            OrderBy = orderByDescExpression;
        }
}
}