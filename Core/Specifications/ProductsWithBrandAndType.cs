using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithBrandAndType : BaseSpecification<Product>
    {
        public ProductsWithBrandAndType(ProductParams productParams) : 
        base(p => 
            (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
            AddOrderBy(p =>p.Name);
            EnablePaging((productParams.PageSize * (productParams.PageIndex-1)),productParams.PageSize);
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
            
            
        }

        public ProductsWithBrandAndType(int id) : base(x => x.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}