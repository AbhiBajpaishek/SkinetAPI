using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetById(int id);

        Task<T> GetEntityWithSpec(ISpecificaton<T> spec);

        Task<List<T>> GetEntityListAsync(ISpecificaton<T> spec);

    }
}