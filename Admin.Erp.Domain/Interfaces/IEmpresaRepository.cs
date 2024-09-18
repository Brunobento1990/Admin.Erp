using Admin.Erp.Domain.Entities;

namespace Admin.Erp.Domain.Interfaces;

public interface IEmpresaRepository : IGenericRepository<Empresa>
{
    Task<Empresa?> GetByRazaoSocialAsync(string razaoSocial);
    Task<Empresa?> GetByIdAsync(Guid id);
}
