using Admin.Erp.Application.ViewModel;

namespace Admin.Erp.Application.Interfaces;

public interface IJwtService
{
    string GerarJwtUsuario(UsuarioViewModel usuarioViewModel);
}
