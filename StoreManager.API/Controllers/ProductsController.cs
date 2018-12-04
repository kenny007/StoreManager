using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreManager.API.Entities;
using StoreManager.API.Models;
using StoreManager.API.Services;

namespace StoreManager.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        // GET
        public ProductsController(IMapper mapper, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        [HttpGet()]
        public async Task<IActionResult> GetProducts()
        {
            var productsEntities = await _productsRepository.GetProductsAsync();
            var products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(productsEntities);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productEntity = await _productsRepository.GetProductAsync(id);
            if (productEntity == null)
            {
                var productsEntities = await _productsRepository.GetProductsAsync();
                var products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(productsEntities);
                return Ok(products);
            }

            var product = _mapper.Map<Product, ProductResource>(productEntity);
            
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] NewProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                var errors =  ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray();
                return BadRequest(errors);
            }      
            var productWithId =   _productsRepository.AddProduct(productResource);
            productResource.ProductId = productWithId.ProductId;  
            _productsRepository.AddProductStore(productResource);

            await _productsRepository.SaveChangesAsync();

            return Ok(productResource);
        }
        
        [HttpGet("ProductGroups")]
        public IActionResult ProductGroups()
        {
            var tempList = _productsRepository.ListGroups();
            return Content(JsonConvert.SerializeObject(new { data =  _productsRepository.GetGroups(tempList) },Formatting.Indented),"application/json");
            
          
        }
      
    }
}