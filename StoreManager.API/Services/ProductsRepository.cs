using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using StoreManager.API.Contexts;
using StoreManager.API.Entities;
using StoreManager.API.Models;

namespace StoreManager.API.Services
{
    public class ProductsRepository: IProductsRepository, IDisposable
    {
        private ProductDbContext _context;

        public ProductsRepository(ProductDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product AddProduct(NewProductResource addToProduct)
        {
            var product = new Product
            {
                ProductName = addToProduct.ProductName,
                ProductGroupId = addToProduct.ProductGroupId,
                DateAdded = DateTime.UtcNow
            };
            _context.Products.Add(product);
            _context.SaveChanges();   
            return product;
        }

        public void AddProductStore(NewProductResource addProductStore)
        {
                 
            foreach (int storeId in addProductStore.Stores)
            {
                var productStore = new ProductStore
                {
                    StoreId = storeId,
                    ProductId = addProductStore.ProductId,
                    Price = addProductStore.Price ??
                            addProductStore.PriceWithVat / (1 + (addProductStore.VatRate / 100)),
                    PriceWithVaT = addProductStore.PriceWithVat ??
                                   addProductStore.Price + (addProductStore.VatRate / 100) * addProductStore.Price,
                    VatRate = addProductStore.VatRate ??
                              ((addProductStore.PriceWithVat / addProductStore.Price) - 1) * 100
                };
                _context.Add(productStore);
            }
        }
        
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(p=>p.ProductStores)
                .ThenInclude(p=>p.Store)
                .Include(c=>c.ProductGroup)   
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await 
                _context.Products.Include(p=>p.ProductStores)
                    .ThenInclude(p=>p.Store)
                    .Include(c=>c.ProductGroup)                   
                    .ToListAsync();
        }

        public List<ProductGroup> ListGroups()
        {
            List<ProductGroup> temp = _context.ProductGroups.Include(x => x.SubProductGroup)
                .Where(x => x.ParentProductGroup == null)
                .Select(c => new ProductGroup
                {
                    ProductGroupId = c.ProductGroupId,
                    Name = c.Name, ParentId = c.ParentId, SubProductGroup = c.SubProductGroup
                }).ToList();
           
            return temp;
        }

        public List<ProductGroup> GetGroups(List<ProductGroup> groups)
        {
            int a = 0;
            List<ProductGroup> lists = new List<ProductGroup>();

            if(groups.Count > 0)
            {
                lists.AddRange(groups);
            }

            foreach(ProductGroup grp in groups)
            {
                ProductGroup groupNode = _context.ProductGroups.Include(g => g.SubProductGroup)
                    .Where(g => g.ProductGroupId == grp.ProductGroupId)
                    .Select(g => new ProductGroup()
                    {
                        ProductGroupId = g.ProductGroupId, Name = g.Name,
                        ParentId = g.ParentId, SubProductGroup = g.SubProductGroup
                    }).First();
                    
                   
                if(groupNode.SubProductGroup == null)
                {
                    a++;
                    continue;
                }

                List<ProductGroup> subNode = groupNode.SubProductGroup.ToList();
                groupNode.SubProductGroup = GetGroups(subNode);
                lists[a] = groupNode;
                a++;
            }
            return lists;
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