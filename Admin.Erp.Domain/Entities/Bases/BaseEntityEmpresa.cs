namespace Admin.Erp.Domain.Entities.Bases;

public abstract class BaseEntityEmpresa : BaseEntity
{
    protected BaseEntityEmpresa(
        Guid id, 
        DateTime criadoEm, 
        DateTime atualizadoEm, 
        Guid empresaId) : base(id, criadoEm, atualizadoEm)
    {
        EmpresaId = empresaId;
    }

    public Guid EmpresaId { get; protected set; }
}
