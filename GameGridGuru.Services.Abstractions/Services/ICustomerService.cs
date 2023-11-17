using GameGridGuru.Domain.Models;

namespace GameGridGuru.Services.Abstractions.Services;

public interface ICustomerService
{
    public Task<bool> AddCustomerAsync(Customer customer);
    public Task<IEnumerable<Customer>> GetCustomersAsync();
    public Task<bool> EditCustomerAsync(Customer customer);
    public Task<bool> DeleteCustomerAsync(Customer customer);
    public Task<Customer?> GetCustomerById(int id);
}