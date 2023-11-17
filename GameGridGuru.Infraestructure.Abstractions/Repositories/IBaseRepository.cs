using GameGridGuru.Domain.Models;

namespace GameGridGuru.Infraestructure.Abstractions.Repositories;

public interface IBaseRepository<T> where T : EntityId
{
    public Task<bool> AddAsync(T entity);
    public Task<bool> EditAsync(T entity);
    public Task<bool> DeleteAsync(T entity);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetEntityById(int id);
}