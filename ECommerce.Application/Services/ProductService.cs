using ECommerce.Application.Dtos;
using ECommerce.Application.Ports;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found.");
            return new ProductDto(product.Id, product.Name, product.Price, product.Stock);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock));
        }

        public async Task<ProductDto> CreateProductAsync(string name, decimal price, int stock)
        {
            var product = new Product(Guid.NewGuid(), name, price, stock);
            await _productRepository.AddAsync(product);
            return new ProductDto(product.Id, product.Name, product.Price, product.Stock);
        }

        public async Task UpdateProductAsync(Guid id, string name, decimal price, int stock)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found.");
            product.UpdateName(name);
            product.UpdatePrice(price);
            product.UpdateStock(stock);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}