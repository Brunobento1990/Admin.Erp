using Admin.Erp.Domain.Interfaces;

namespace Admin.Erp.Infrastructure.Models;

public sealed class UsuarioAutenticado : IUsuarioAutenticado
{
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
    public Guid PerfilUsuarioId { get ; set ; }
}
