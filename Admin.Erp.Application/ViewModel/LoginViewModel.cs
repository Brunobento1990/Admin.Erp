namespace Admin.Erp.Application.ViewModel;

public class LoginViewModel
{
    public LoginViewModel(string token, UsuarioViewModel usuario, IList<MenuViewModel> menus)
    {
        Token = token;
        Usuario = usuario;
        Menus = menus;
    }

    public string Token { get; set; }
    public UsuarioViewModel Usuario { get; set; }
    public IList<MenuViewModel> Menus { get; set; }
}
