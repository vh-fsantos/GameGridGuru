using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly PostgresDbContext _dbContext;
    
    public CustomerRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> AddCustomerAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditCustomerAsync(Customer customer)
    {
        try
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync() 
        => await _dbContext.Customers.AsNoTracking().OrderBy(customer => customer.Id).ToListAsync();

    public async Task<Customer?> GetCustomerById(int id)
        => await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(customer => customer.Id == id);
}