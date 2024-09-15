using Admin.Erp.Domain.Entities.Bases;

namespace Admin.Erp.Domain.Entities;

public sealed class Empresa : BaseEntity
{
    public Empresa(
        Guid id,
        DateTime criadoEm,
        DateTime atualizadoEm,
        string razaoSocial,
        string nomeFantasia,
        string cnpj,
        bool premium)
            : base(id, criadoEm, atualizadoEm)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        Premium = premium;
    }

    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public bool Premium { get; private set; }
}
