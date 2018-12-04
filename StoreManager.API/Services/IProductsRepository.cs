using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.API.Entities;

namespace StoreManager.API.Services
{
    public interface IProductsRepository
    {
        Task <IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task AddProductAsync(Product product);
    }
}