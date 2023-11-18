using GameGridGuru.Domain.Models;

namespace GameGridGuru.Services.Abstractions.Services;

public interface IBaseService<T> where T : EntityId
{
    public Task<bool> AddEntityAsync(T entity);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<bool> EditEntityAsync(T entity);
    public Task<bool> DeleteEntityAsync(T entity);
    public Task<T?> GetEntityById(int id);
}