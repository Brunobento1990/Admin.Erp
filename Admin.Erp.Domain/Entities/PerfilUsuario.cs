using Admin.Erp.Domain.Entities.Bases;

namespace Admin.Erp.Domain.Entities;

public sealed class PerfilUsuario : BaseEntityEmpresa
{
    public PerfilUsuario(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        Guid empresaId,
        string descricao,
        bool ativo)
            : base(id, criadoEm, atualizadoEm, empresaId)
    {
        Descricao = descricao;
        Ativo = ativo;
    }

    public string Descricao { get; private set; }
    public bool Ativo { get; private set; }
    public IList<Usuario> Usuarios { get; set; } = [];
    public IList<PerfilUsuarioMenu> PerfilUsuarioMenu { get; set; } = [];

    public static PerfilUsuario NovoPerfil(string descricao, Guid empresaId)
    {
        return new PerfilUsuario(
            id: Guid.CreateVersion7(),
            criadoEm: DateTime.Now,
            atualizadoEm: DateTime.Now,
            empresaId: empresaId,
            descricao: descricao,
            ativo: true);
    }
}
