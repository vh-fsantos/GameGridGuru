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
        => await _customerRepository.AddCustomerAsync(customer);

    public async Task<IEnumerable<Customer>> GetCustomersAsync() 
        => await _customerRepository.GetCustomersAsync();

    public async Task<bool> EditCustomerAsync(Customer customer)
        => await _customerRepository.EditCustomerAsync(customer);

    public async Task<Customer?> GetCustomerById(int id)
        => await _customerRepository.GetCustomerById(id);
}