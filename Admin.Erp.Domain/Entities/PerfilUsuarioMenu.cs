using Admin.Erp.Domain.Entities.Global;

namespace Admin.Erp.Domain.Entities;

public sealed class PerfilUsuarioMenu
{
    public PerfilUsuarioMenu(Guid menuId, Guid perfilUsuarioId, Guid id)
    {
        MenuId = menuId;
        PerfilUsuarioId = perfilUsuarioId;
        Id = id;
    }
    public Guid Id { get; private set; }
    public Guid MenuId { get; private set; }
    public Menu Menu { get; set; } = null!;
    public Guid PerfilUsuarioId { get; private set; }
    public PerfilUsuario PerfilUsuario { get; set; } = null!;
    public IList<PerfilUsuarioMenuRota> PerfilUsuarioMenuRota { get; set; } = [];
}
