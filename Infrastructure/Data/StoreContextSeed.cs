using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){
            try{
                if(!context.ProductTypes.Any())
                {
                    var productBrands = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrands);
                    foreach(var brand in brands){
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.ProductTypes.Any())
                {
                    var productTypes = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypes);
                    foreach(var productType in types){
                        context.ProductTypes.Add(productType);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any())
                {
                    var products = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var product = JsonSerializer.Deserialize<List<Product>>(products);
                    foreach(var item in product){
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex,"Error occured while seeding data");
            }
        }
    }
}