using GameGridGuru.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure.Repositories;

public class Repository
{
    private readonly SqLiteDbContext _dbContext = new();
    
    public async Task<bool> AddCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        var teste = await _dbContext.SaveChangesAsync();
        return false;
    }
    
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var teste = await _dbContext.Customers
            .ToListAsync();
        return await _dbContext.Customers
            .ToListAsync();
    }
}