using Admin.Erp.Domain.Entities;

namespace Admin.Erp.Domain.Interfaces;

public interface ILoginRepository
{
    Task<Usuario?> LoginAsync(string cpf);
}
