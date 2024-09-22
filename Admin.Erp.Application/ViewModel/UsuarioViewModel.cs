using Admin.Erp.Domain.Entities;

namespace Admin.Erp.Application.ViewModel;

public class UsuarioViewModel
{
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
    public Guid PerfilUsuarioId { get; set; }
    public string Nome { get; set; } = string.Empty;

    public static explicit operator UsuarioViewModel(Usuario usuario)
    {
        return new UsuarioViewModel()
        {
            Nome = usuario.Nome,
            EmpresaId = usuario.EmpresaId,
            Id = usuario.Id,
            PerfilUsuarioId = usuario.PerfilUsuarioId
        };
    }
}
