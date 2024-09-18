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
        DateTime? dataDeNascimento)
            : base(id, criadoEm, atualizadoEm, empresaId)
    {
        Nome = nome;
        Cpf = cpf;
        DataDeNascimento = dataDeNascimento;
    }

    public string Nome { get; protected set; }
    public NpgsqlTsVector Search { get; set; }
    public string? Cpf { get; protected set; }
    public DateTime? DataDeNascimento { get; protected set; }
}
