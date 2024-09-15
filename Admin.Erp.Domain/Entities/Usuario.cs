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
        NpgsqlTsVector search,
        string senha)
            : base(id, criadoEm, atualizadoEm, empresaId, nome, cpf, dataDeNascimento, search)
    {
        Senha = senha;
    }

    public string Senha { get; private set; }
}
