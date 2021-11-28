using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private StoreContext _context { get; set;}
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecificaton<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetEntityListAsync(ISpecificaton<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync<T>();
        }


        public IQueryable<T> ApplySpecification(ISpecificaton<T> spec){
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }
    }
}