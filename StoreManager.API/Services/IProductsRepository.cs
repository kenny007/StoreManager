using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.API.Entities;
using StoreManager.API.Models;

namespace StoreManager.API.Services
{
    public interface IProductsRepository
    {
        Task <IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Product AddProduct(NewProductResource productResource);
        void AddProductStore(NewProductResource productResource);
        Task<bool> SaveChangesAsync();
    }
}