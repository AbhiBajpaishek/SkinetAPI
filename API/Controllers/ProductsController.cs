using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {   
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo ){
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            return await _repo.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _repo.GetProductByID(id);
        }

        [Route("brands")]
        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands(){
            return await _repo.GetProductBrands();
        }

        [Route("types")]
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes(){
            return await _repo.GetProductTypes();
        }
    }
}