using Admin.Erp.Application.Interfaces;
using Admin.Erp.Application.ViewModel;
using Admin.Erp.Domain.Entities.Global;
using Admin.Erp.Domain.Interfaces;

namespace Admin.Erp.Application.Services;

public sealed class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<IList<MenuViewModel>> GetMenusAsync(bool isPremium)
    {
        var menus = await _menuRepository.ListMenuAsync(isPremium);
        return OrdenarFilhos(menus, x => !x.MenuId.HasValue);
    }

    static IList<MenuViewModel> OrdenarFilhos(IList<Menu> menus, Func<Menu, bool> expression)
    {
        return menus.OrderBy(x => x.Ordem).Where(expression).Select(x => new MenuViewModel
        {
            Icone = x.Icone,
            Id = x.Id,
            Ordem = x.Ordem,
            Path = x.Path,
            Filhos = OrdenarFilhos(menus, y => y.MenuId == x.MenuId)
        }).ToList();
    }
}
