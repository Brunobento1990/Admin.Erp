using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;

namespace Admin.Erp.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
{
    protected readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(T entity)
    {
        await _appDbContext.AddAsync(entity!);
    }

    public void Delete(T entity)
    {
        _appDbContext.Attach(entity!);
        _appDbContext.Remove(entity!);
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _appDbContext.Update(entity!);
        _appDbContext.Remove(entity!);
    }
}
