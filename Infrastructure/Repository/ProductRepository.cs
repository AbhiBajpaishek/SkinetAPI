using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext _context { get; }
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

         public async Task<List<Product>> GetProducts()
        {
          return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }

        public async Task<Product> GetProductByID(int id)
        {
           return await _context.Products
           .Include(p => p.ProductBrand)
           .Include(p => p.ProductType)
           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProductBrand>> GetProductBrands()
        {
            return  await _context.ProductBrands.ToListAsync<ProductBrand>();
        }

        public async Task<List<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync<ProductType>();
        }

    }
}