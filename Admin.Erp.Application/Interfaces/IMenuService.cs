using Admin.Erp.Application.ViewModel;

namespace Admin.Erp.Application.Interfaces;

public interface IMenuService
{
    Task<IList<MenuViewModel>> GetMenusAsync(bool isPremium);
}
