using Admin.Erp.Domain.Interfaces;

namespace Admin.Erp.Infrastructure.Models;

public sealed class EmpresaAutenticada : IEmpresaAutenticada
{
    public bool Premium { get ; set ; }
    public Guid Id { get ; set ; }
}
