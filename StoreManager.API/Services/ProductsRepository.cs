using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreManager.API.Contexts;
using StoreManager.API.Entities;

namespace StoreManager.API.Services
{
    public class ProductsRepository: IProductsRepository, IDisposable
    {
        private ProductDbContext _context;

        public ProductsRepository(ProductDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(p=>p.ProductStores)
                .ThenInclude(p=>p.Store)
                .Include(c=>c.ProductGroup)   
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public Task AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await 
                _context.Products.Include(p=>p.ProductStores)
                    .ThenInclude(p=>p.Store)
                    .Include(c=>c.ProductGroup)                   
                    .ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}