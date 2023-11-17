using GameGridGuru.Domain.Models;

namespace GameGridGuru.Infraestructure.Abstractions.Repositories;

public interface ICustomerRepository
{
    Task<bool> AddCustomerAsync(Customer customer);
    Task<bool> EditCustomerAsync(Customer customer);
    Task<bool> DeleteCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerById(int id);
}