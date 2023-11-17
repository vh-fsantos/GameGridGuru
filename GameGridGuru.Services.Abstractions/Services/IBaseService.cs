using GameGridGuru.Domain.Models;

namespace GameGridGuru.Services.Abstractions.Services;

public interface IBaseService<T> where T : EntityId
{
    public Task<bool> AddEntityAsync(T customer);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<bool> EditEntityAsync(T customer);
    public Task<bool> DeleteEntityAsync(T customer);
    public Task<T?> GetEntityById(int id);
}