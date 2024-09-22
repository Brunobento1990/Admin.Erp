using Admin.Erp.Domain.Entities;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Erp.Infrastructure.Repositories;

public sealed class AmbienteDesenvolvimentoRepository : IAmbienteDesenvolvimentoRepository
{
    private readonly AppDbContext _appDbContext;

    public AmbienteDesenvolvimentoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddEmpresaAsync(Empresa empresa)
    {
        await _appDbContext.AddAsync(empresa);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task AddPerfilAsync(PerfilUsuario perfilUsuario)
    {
        await _appDbContext.AddAsync(perfilUsuario);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task AddUsuarioAsync(Usuario usuario)
    {
        await _appDbContext.AddAsync(usuario);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Empresa?> GetEmpresaDevAsync(string nome)
    {
        return await _appDbContext
            .Empresas
            .FirstOrDefaultAsync(x => x.RazaoSocial == nome);
    }

    public async Task RodarMigrationAsync()
    {
        await _appDbContext.Database.MigrateAsync();
    }
}
