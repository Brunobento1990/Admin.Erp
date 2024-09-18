using Admin.Erp.Domain.Entities;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Erp.Infrastructure.Repositories;

public sealed class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
{
    public EmpresaRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<Empresa?> GetByIdAsync(Guid id)
    {
        return await _appDbContext
            .Empresas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Empresa?> GetByRazaoSocialAsync(string razaoSocial)
    {
        return await _appDbContext
            .Empresas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RazaoSocial == razaoSocial);
    }
}
