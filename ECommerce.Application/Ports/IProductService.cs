using ECommerce.Application.Dtos;



namespace ECommerce.Application.Ports
{
    public interface IProductService
    {
        Task<ProductDto> GetProductAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(string name, decimal price, int stock);
        Task UpdateProductAsync(Guid id, string name, decimal price, int stock);
        Task DeleteProductAsync(Guid id);
    }
}