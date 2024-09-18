using Admin.Erp.Domain.Entities.Global;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Erp.Infrastructure.Repositories;

public sealed class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _appDbContext;

    public MenuRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IList<Menu>> ListMenuAsync(bool isPremium)
    {
        return await _appDbContext
            .Menus
            .AsNoTracking()
            .Where(x => !x.Premium || x.Premium == isPremium)
            .ToListAsync();
    }
}
