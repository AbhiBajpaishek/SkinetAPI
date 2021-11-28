using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BaseSpecification<TEntity> : ISpecificaton<TEntity> where TEntity : BaseEntity
    {
        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public BaseSpecification()
        {
        }

        public List<Expression<Func<TEntity, object>>> Includes {get; set;}  = new List<Expression<Func<TEntity, object>>>(); 
        public Expression<Func<TEntity, bool>> Criteria { get; set;}


        protected void AddIncludes(Expression<Func<TEntity,object>> expression)
        {
            Includes.Add(expression);
        }
    }
}