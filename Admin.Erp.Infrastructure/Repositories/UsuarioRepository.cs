using Admin.Erp.Domain.Entities;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Context;

namespace Admin.Erp.Infrastructure.Repositories;

public sealed class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
