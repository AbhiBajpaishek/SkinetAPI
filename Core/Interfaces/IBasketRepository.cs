using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket> GetBasketAsync(string basketId);
        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
        public Task<bool> DeleteBasketAsync(string basketId);

    }
}