using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductByID(int id);
        public Task<List<ProductBrand>> GetProductBrands();
        public Task<List<ProductType>> GetProductTypes();
    }
}