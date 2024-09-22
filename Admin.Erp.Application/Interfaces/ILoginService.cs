using Admin.Erp.Application.Dtos.Logins;
using Admin.Erp.Application.ViewModel;

namespace Admin.Erp.Application.Interfaces;

public interface ILoginService
{
    Task<LoginViewModel> LoginAsync(LoginDto loginDto);
}
