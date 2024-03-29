using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class CustomerService : BaseService<Customer>, ICustomerService
{
    public CustomerService(ICustomerRepository customerRepository) : base(customerRepository) { }
}