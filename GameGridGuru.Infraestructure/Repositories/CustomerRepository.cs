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
        try
        {
            await GetDbSet().AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Add Customer - {exception.Message}");
            return false;
        }
        finally
        {
            ClearChangeTracker();
        }
    }

    public async Task<bool> EditCustomerAsync(Customer customer)
    {
        try
        {
            GetDbSet().Update(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Edit Customer - {exception.Message}");
            return false;
        }
        finally
        {
            ClearChangeTracker();
        }
    }

    public async Task<bool> DeleteCustomerAsync(Customer customer)
    {
        try
        {
            GetDbSet().Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Remove Customer - {exception.Message}");
            return false;
        }
        finally
        {
            ClearChangeTracker();
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync() 
        => await GetDbSet().AsNoTracking().OrderBy(customer => customer.Id).ToListAsync();

    public async Task<Customer?> GetCustomerById(int id)
        => await GetDbSet().AsNoTracking().FirstOrDefaultAsync(customer => customer.Id == id);

    private DbSet<Customer> GetDbSet()
        => _dbContext.Customers;

    private void ClearChangeTracker()
    {
        _dbContext.ChangeTracker.Clear();
    }
}