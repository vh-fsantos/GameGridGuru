using GameGridGuru.Domain.Models;

namespace GameGridGuru.Infraestructure.Abstractions.Repositories;

public interface IProductRepository
{
    Task<bool> AddProductAsync(Product product);
    Task<bool> EditProductAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductById(int id);
}