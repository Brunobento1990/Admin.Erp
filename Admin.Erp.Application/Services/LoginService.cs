using Admin.Erp.Application.Dtos.Logins;
using Admin.Erp.Application.Interfaces;
using Admin.Erp.Application.ViewModel;
using Admin.Erp.Domain.Exceptions;
using Admin.Erp.Domain.Interfaces;

namespace Admin.Erp.Application.Services;

public sealed class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMenuService _menuService;
    private readonly IJwtService _jwtService;

    public LoginService(
        ILoginRepository loginRepository,
        IEmpresaRepository empresaRepository,
        IMenuService menuService,
        IJwtService jwtService)
    {
        _loginRepository = loginRepository;
        _empresaRepository = empresaRepository;
        _menuService = menuService;
        _jwtService = jwtService;
    }

    public async Task<LoginViewModel> LoginAsync(LoginDto loginDto)
    {
        var usuario = await _loginRepository.LoginAsync(cpf: loginDto.Cpf)
            ?? throw new ErroApiException("CPF ou senha inválidos!");

        if (usuario.AcessoUsuario.Bloqueado)
        {
            throw new ErroApiException("Seu acesso está bloqueado");
        }

        var usuarioViewModel = (UsuarioViewModel)usuario;

        //var menus = await _menuService.GetMenusAsync();

        var jwt = _jwtService.GerarJwtUsuario(usuarioViewModel);

        return new LoginViewModel(token: jwt, usuario: usuarioViewModel, menus: []);
    }
}
