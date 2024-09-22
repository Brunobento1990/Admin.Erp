using Admin.Erp.Domain.Entities.Bases;

namespace Admin.Erp.Domain.Entities.Global;

public sealed class MenuRota : BaseEntity
{
    public MenuRota(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        Guid menuId,
        string rota,
        string descricao)
            : base(id, criadoEm, atualizadoEm)
    {
        MenuId = menuId;
        Rota = rota;
        Descricao = descricao;
    }
    public string Rota { get; private set; }
    public string Descricao { get; private set; }
    public Guid MenuId { get; private set; }
    public Menu Menu { get; set; } = null!;
}
