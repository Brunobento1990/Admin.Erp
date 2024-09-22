using Admin.Erp.Domain.Entities;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Erp.Infrastructure.Repositories;

public sealed class LoginRepository : ILoginRepository
{
    private readonly AppDbContext _appDbContext;

    public LoginRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Usuario?> LoginAsync(string cpf)
    {
        return await _appDbContext
            .Usuarios
            .AsNoTracking()
            .Include(x => x.AcessoUsuario)
            .FirstOrDefaultAsync(x => x.Cpf!.ToLower() == cpf.ToLower());
    }
}
