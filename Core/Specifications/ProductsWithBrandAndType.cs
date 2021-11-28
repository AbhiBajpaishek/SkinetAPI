using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithBrandAndType : BaseSpecification<Product>
    {
        public ProductsWithBrandAndType()
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }

        public ProductsWithBrandAndType(int id) : base(x => x.Id == id)
        {   
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}