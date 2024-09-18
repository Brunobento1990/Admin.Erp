using Admin.Erp.Domain.Entities.Bases;
using NpgsqlTypes;

namespace Admin.Erp.Domain.Entities;

public sealed class Usuario : BaseEntityPessoa
{
    public Usuario(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        Guid empresaId,
        string nome,
        string? cpf,
        DateTime? dataDeNascimento,
        string senha)
            : base(id, criadoEm, atualizadoEm, empresaId, nome, cpf, dataDeNascimento)
    {
        Senha = senha;
    }
    public AcessoUsuario AcessoUsuario { get; set; } = null!;
    public string Senha { get; private set; }
}
