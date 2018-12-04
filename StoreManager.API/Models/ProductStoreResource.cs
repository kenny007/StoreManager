using StoreManager.API.Entities;

namespace StoreManager.API.Models
{
    public class ProductStoreResource
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceWithVaT { get; set; }
        public decimal? VatRate { get; set; }
    }
}