using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories;

public class BaseRepository<T>(KazemaruDbContext db) : IBaseRepository<T> where T : class
{
    private readonly KazemaruDbContext _db = db;
    
    public async Task<T> Create(T entity)
    {
        try
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IQueryable<T> Queryable()
    {
        try
        {
            return _db.Set<T>().AsQueryable();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T?> Update(T entity)
    {
        try
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T> Delete(T entity)
    {
        try
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}