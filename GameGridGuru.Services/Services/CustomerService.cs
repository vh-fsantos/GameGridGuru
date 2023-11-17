using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<bool> AddCustomerAsync(Customer customer) 
        => await _customerRepository.AddAsync(customer);

    public async Task<IEnumerable<Customer>> GetCustomersAsync() 
        => await _customerRepository.GetAllAsync();

    public async Task<bool> EditCustomerAsync(Customer customer)
        => await _customerRepository.EditAsync(customer);
    
    public async Task<bool> DeleteCustomerAsync(Customer customer)
        => await _customerRepository.DeleteAsync(customer);

    public async Task<Customer?> GetCustomerById(int id)
        => await _customerRepository.GetEntityById(id);
}