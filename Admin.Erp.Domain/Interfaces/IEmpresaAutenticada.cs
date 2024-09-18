namespace Admin.Erp.Domain.Interfaces;

public interface IEmpresaAutenticada
{
    bool Premium { get; set; }
    Guid Id { get; set; }
}
