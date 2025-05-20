namespace ECommerce.Application.Dtos
{
    public record ProductDto(Guid Id, string Name, decimal Price, int Stock);
}