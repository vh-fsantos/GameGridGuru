using GameGridGuru.Domain.Models;

namespace GameGridGuru.Infraestructure.Repositories;

public class Repository
{
    private readonly SqLiteDbContext _dbContext = new();
    
    public async Task<bool> AddCustomerAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}