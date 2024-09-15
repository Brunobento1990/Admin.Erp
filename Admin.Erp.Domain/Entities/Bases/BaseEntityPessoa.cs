using NpgsqlTypes;

namespace Admin.Erp.Domain.Entities.Bases;

public abstract class BaseEntityPessoa : BaseEntityEmpresa
{
    protected BaseEntityPessoa(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        Guid empresaId,
        string nome,
        string? cpf,
        DateTime? dataDeNascimento,
        NpgsqlTsVector search)
            : base(id, criadoEm, atualizadoEm, empresaId)
    {
        Nome = nome;
        Cpf = cpf;
        DataDeNascimento = dataDeNascimento;
        Search = search;
    }

    public string Nome { get; protected set; }
    public NpgsqlTsVector Search { get; protected set; }
    public string? Cpf { get; protected set; }
    public DateTime? DataDeNascimento { get; protected set; }
}
