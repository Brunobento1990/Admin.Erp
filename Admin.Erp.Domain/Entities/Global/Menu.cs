using Admin.Erp.Domain.Entities.Bases;

namespace Admin.Erp.Domain.Entities.Global;

public sealed class Menu : BaseEntity
{
    public Menu(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        string path,
        string? icone,
        int ordem,
        bool premium,
        Guid? menuId)
            : base(id, criadoEm, atualizadoEm)
    {
        Path = path;
        Icone = icone;
        Ordem = ordem;
        Premium = premium;
        MenuId = menuId;
    }

    public string Path { get; private set; }
    public string? Icone { get; private set; }
    public int Ordem { get; private set; }
    public bool Premium { get; private set; }
    public Guid? MenuId { get; private set; }
    public IList<MenuRota> MenuRotas { get; set; } = [];
    public PerfilUsuarioMenu PerfilUsuarioMenu { get; set; } = null!;
}
