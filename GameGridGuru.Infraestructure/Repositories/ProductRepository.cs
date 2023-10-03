using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PostgresDbContext _dbContext;
    
    public ProductRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditProductAsync(Product product)
    {
        try
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
        => await _dbContext.Products.AsNoTracking().OrderBy(product => product.Id).ToListAsync();

    public async Task<Product?> GetProductById(int id)
        => await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(customer => customer.Id == id);
}