using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.API.Entities
{
    [Table("ProductStores")]
    public class ProductStore
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceWithVaT { get; set; }
        [Column(TypeName = "decimal(6,4)")]
        public decimal? VatRate { get; set; }
    }
}