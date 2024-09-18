using Admin.Erp.Application.Interfaces;
using Admin.Erp.Application.ViewModel;
using Admin.Erp.Domain.Entities.Global;
using Admin.Erp.Domain.Interfaces;

namespace Admin.Erp.Application.Services;

public sealed class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly IEmpresaAutenticada _empresaAutenticada;

    public MenuService(IMenuRepository menuRepository, IEmpresaAutenticada empresaAutenticada)
    {
        _menuRepository = menuRepository;
        _empresaAutenticada = empresaAutenticada;
    }

    public async Task<IList<MenuViewModel>> GetMenusAsync()
    {
        var menus = await _menuRepository.ListMenuAsync(isPremium: _empresaAutenticada.Premium);
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
