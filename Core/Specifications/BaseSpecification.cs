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
        public Expression<Func<TEntity, object>> OrderBy { get; set;}
        public Expression<Func<TEntity, object>> OrderByDesc { get; set;}
        public int Skip { get; set;}
        public int Take { get; set;}
        public bool IsPagingEnabled {get; set;}

        protected void AddIncludes(Expression<Func<TEntity,object>> expression)
        {
            Includes.Add(expression);
        }

        protected void AddOrderBy(Expression<Func<TEntity,object>> orderby)
        {
            OrderBy = orderby;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity,object>> orderByDesc)
        {
            OrderByDesc = orderByDesc;
        }

        protected void EnablePaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}