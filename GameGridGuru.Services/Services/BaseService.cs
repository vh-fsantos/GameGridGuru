using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;

namespace GameGridGuru.Services.Services;

public abstract class BaseService<T> where T : EntityId
{
    private readonly IBaseRepository<T> _baseRepository;
    
    protected BaseService(IBaseRepository<T> baseRepository)
    {
        _baseRepository = baseRepository;
    }
    
    public async Task<bool> AddEntityAsync(T customer)
        => await _baseRepository.AddAsync(customer);

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _baseRepository.GetAllAsync();

    public async Task<bool> EditEntityAsync(T customer)
        => await _baseRepository.EditAsync(customer);

    public async Task<bool> DeleteEntityAsync(T customer)
        => await _baseRepository.DeleteAsync(customer);

    public async Task<T?> GetEntityById(int id)
        => await _baseRepository.GetEntityById(id);
}