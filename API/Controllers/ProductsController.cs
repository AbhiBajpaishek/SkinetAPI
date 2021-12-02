using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo,
                                IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturn>>> GetProducts([FromQuery]ProductParams productparams)
        {
            var spec = new ProductsWithBrandAndType(productparams);

            var countSpec = new ProductWithFiltersSpecificification(productparams);

            var products = await _productRepo.GetEntityListAsync(spec);
            var count = await _productRepo.CountAsync(countSpec);


            var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturn>>(products);

            return Ok(new Pagination<ProductToReturn>(productparams.PageSize,productparams.PageIndex,count,data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturn),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepo.GetEntityWithSpec(new ProductsWithBrandAndType(id));
            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Product,ProductToReturn>(product));
        }

        [Route("brands")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.GetAllAsync());
        }
    }
}