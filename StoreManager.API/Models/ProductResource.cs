using System;
using System.Collections.Generic;
using Remotion.Linq.Clauses.ResultOperators;
using StoreManager.API.Entities;

namespace StoreManager.API.Models
{
    public class ProductResource
    {
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        public DateTime DateAdded { get; set; }
        public string ProductGroup { get; set; }

        public ICollection<KeyValuePairResource> Stores { get; set; }
       // public List<ProductStore> ProductStores { get; set; } = new List<ProductStore>();
    }
}