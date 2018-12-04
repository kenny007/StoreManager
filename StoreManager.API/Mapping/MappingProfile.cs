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
            CreateMap<ProductStore, ProductStoreResource>();
            CreateMap<Product, ProductResource>()
                .ForMember(dest => dest.ProductGroup, opt => opt.MapFrom(c => c.ProductGroup.Name))
                .ForMember(dest=> dest.StoreAvailableCount, opt => opt.MapFrom(c=>c.ProductStores.Count))
                .ForMember(dest => dest.ProductStores, opt => opt.MapFrom(s => s.ProductStores
                    .Select(ps => new ProductStoreResource 
                        {StoreId = ps.Store.Id, Name = ps.Store.Name, Price = ps.Price, VatRate = ps.VatRate, PriceWithVaT = ps.PriceWithVaT})));
        }
    }
}