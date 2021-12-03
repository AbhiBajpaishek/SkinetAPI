using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket customerBasket)
        {
            return Ok(await _basketRepository.UpdateBasketAsync(customerBasket));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id)
        {
            bool isDeleted = await _basketRepository.DeleteBasketAsync(id);
            if(isDeleted)
                return Ok();
            else
                return NotFound(id + " not Deleted" );
        }

    }
}