using dj_shop.Models;
using dj_shop.Services;
using Microsoft.AspNetCore.Mvc;
using dj_shop.Interfaces;

namespace dj_shop.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null || !products.Any())
            {
                return products == null || !products.Any() ? NotFound("[]") : Ok(products);
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetId(int id)
        {
            var products = await _productService.GetProductByIdAsync(id);

            if (products == null)
            {
                return NotFound($"Product with ID {id} was not found");
            }
            return Ok(products);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<ProductModel>>> GetCategory(string category)
        {
            var products = await _productService.GetProductByCategory(category);

            if (products == null)
            {
                return NotFound($"No products found in category '{category}'.");
            }
            return Ok(products);
        }
    }
}
