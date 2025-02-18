namespace backend.Repositories.Contract;

public interface IBaseRepository<T> where T : class
{
    public Task<T> Create(T entity);
    public IQueryable<T> Queryable();
    public Task<T?> Update(T entity);
    public Task<T> Delete(T entity);
}