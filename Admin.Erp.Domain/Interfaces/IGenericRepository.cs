namespace Admin.Erp.Domain.Interfaces;

public interface IGenericRepository<T>
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
