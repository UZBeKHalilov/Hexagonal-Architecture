using ECommerce.Application.Dtos;
using ECommerce.Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productService.GetProductAsync(id); // Fixed method name
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var product = await _productService.CreateProductAsync(
                request.Name,
                request.Price,
                request.Stock
            );
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Additional endpoints (PUT, DELETE) can be added here
    }

    public record CreateProductRequest(string Name, decimal Price, int Stock);
}
