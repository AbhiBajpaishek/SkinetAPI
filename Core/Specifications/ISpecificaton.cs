using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public interface ISpecificaton<TEntity> where TEntity : BaseEntity
    {
        public List<Expression<Func<TEntity,object>>> Includes {get; set;}
        public Expression<Func<TEntity,bool>> Criteria { get; set; } 
    }
}