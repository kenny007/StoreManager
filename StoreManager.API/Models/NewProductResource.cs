using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreManager.API.Entities;

namespace StoreManager.API.Models
{
    public class NewProductResource
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }
        [Required]
        public int ProductGroupId { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceWithVat { get; set; }
        public decimal? VatRate { get; set; }

        public ICollection<int> Stores { get; set; }
        //public List<ProductStore> ProductStores { get; set; } = new List<ProductStore>();
    
    }
}