namespace Admin.Erp.Domain.Interfaces;

public interface IUsuarioAutenticado
{
    Guid Id { get; set; }
    Guid EmpresaId { get; set; }
}
