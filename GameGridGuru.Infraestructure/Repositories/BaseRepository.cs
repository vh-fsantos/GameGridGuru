using System.Runtime.CompilerServices;
using GameGridGuru.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure.Repositories;

public abstract class BaseRepository<T> where T : EntityId
{
    private readonly PostgresDbContext _dbContext;
    
    protected BaseRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<bool> AddAsync(T entity)
    {
        try
        {
            await GetDbSet().AddAsync(entity);
            await SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Add Entity Type {nameof(T)} - {exception.Message}");
            return false;
        }
        finally
        {
            ClearChangeTracker();
        }
    }
    
    public async Task<bool> EditAsync(T entity)
    {
        try
        {
            GetDbSet().Update(entity);
            await SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Edit Entity Type {nameof(T)} - {exception.Message}");
            return false;
        }
        finally
        {
            ClearChangeTracker();
        }
    }
    
    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            GetDbSet().Remove(entity);
            await SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Remove Entity Type {nameof(T)}  - {exception.Message}");
            return false;
        }
        finally
        {
            ClearChangeTracker();
        }
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await GetDbSet().AsNoTracking().OrderBy(entity => entity.Id).ToListAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Get All {nameof(T)}  - {exception.Message}");
            return Enumerable.Empty<T>();
        }
    }

    public async Task<T?> GetEntityById(int id)
    {
        try
        {
            return await GetDbSet().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Get Entity by Id {nameof(T)}  - {exception.Message}");
            return null;
        }
    }
    
    protected DbSet<T> GetDbSet() 
        => _dbContext.Set<T>();

    protected async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
    protected void ClearChangeTracker()
    {
        _dbContext.ChangeTracker.Clear();
    }
}