namespace Admin.Erp.Domain.Entities.Bases;

public abstract class BaseEntity
{
    protected BaseEntity(Guid id, DateTime criadoEm, DateTime atualizadoEm)
    {
        Id = id;
        CriadoEm = criadoEm;
        AtualizadoEm = atualizadoEm;
    }

    public Guid Id { get; protected set; }
    public DateTime CriadoEm { get; protected set; }
    public DateTime AtualizadoEm { get; protected set; }
}
