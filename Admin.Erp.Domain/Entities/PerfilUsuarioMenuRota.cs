using Admin.Erp.Domain.Entities.Bases;
using Admin.Erp.Domain.Entities.Global;

namespace Admin.Erp.Domain.Entities;

public sealed class PerfilUsuarioMenuRota : BaseEntity
{
    public PerfilUsuarioMenuRota(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        Guid menuRotaId,
        Guid perfilUsuarioMenuId)
            : base(id, criadoEm, atualizadoEm)
    {
        MenuRotaId = menuRotaId;
        PerfilUsuarioMenuId = perfilUsuarioMenuId;
    }

    public MenuRota MenuRota { get; set; } = null!;
    public Guid MenuRotaId { get; private set; }
    public Guid PerfilUsuarioMenuId { get; private set; }
    public PerfilUsuarioMenu PerfilUsuarioMenu { get; set; } = null!;
}
