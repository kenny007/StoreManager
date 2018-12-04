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

        public int StoreAvailableCount { get; set; }
        public ICollection<ProductStoreResource> ProductStores { get; set; }
    }
}