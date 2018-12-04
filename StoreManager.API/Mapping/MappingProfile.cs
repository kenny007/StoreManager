using System.Linq;
using AutoMapper;
using StoreManager.API.Entities;
using StoreManager.API.Models;

namespace StoreManager.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductGroup, KeyValuePairResource>();
            CreateMap<Product, ProductResource>()
                .ForMember(dest => dest.ProductGroup, opt => opt.MapFrom(c=>c.ProductGroup.Name))
                .ForMember(dest => dest.Stores, opt => opt.MapFrom(s => s.ProductStores
                    .Select(ps => new KeyValuePairResource {Id = ps.Store.Id, Name = ps.Store.Name})));
        }
    }
}