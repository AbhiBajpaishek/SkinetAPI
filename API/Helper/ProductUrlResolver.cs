using API.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturn, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config=config;
        }

        public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)){
                return _config["ApiURL"] + source.PictureUrl;
            }
            return null;
        }
    }
}