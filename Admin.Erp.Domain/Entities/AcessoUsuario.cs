using Admin.Erp.Domain.Entities.Bases;

namespace Admin.Erp.Domain.Entities;

public sealed class AcessoUsuario : BaseEntity
{
    public AcessoUsuario(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        bool bloqueado,
        Guid? tokenEsqueceuSenha,
        DateTime? expiracaoDoTokenEsqueceuSenha,
        Guid usuarioId)
            : base(id, criadoEm, atualizadoEm)
    {
        Bloqueado = bloqueado;
        TokenEsqueceuSenha = tokenEsqueceuSenha;
        ExpiracaoDoTokenEsqueceuSenha = expiracaoDoTokenEsqueceuSenha;
        UsuarioId = usuarioId;
    }

    public bool Bloqueado { get; private set; }
    public Guid? TokenEsqueceuSenha { get; private set; }
    public DateTime? ExpiracaoDoTokenEsqueceuSenha { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
}
