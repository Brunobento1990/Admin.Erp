using Admin.Erp.Domain.Entities.Global;
using Admin.Erp.Domain.Interfaces;
using Admin.Erp.Infrastructure.Cache.Interfaces;
using Admin.Erp.Infrastructure.Repositories;

namespace Admin.Erp.Infrastructure.Cached.Cached;

public sealed class MenuCached : IMenuRepository
{
    private readonly MenuRepository _menuRepository;
    private readonly ICachedService<Menu> _cachedService;

    public MenuCached(MenuRepository menuRepository, ICachedService<Menu> cachedService)
    {
        _menuRepository = menuRepository;
        _cachedService = cachedService;
    }

    public async Task<IList<Menu>> ListMenuAsync(bool isPremium)
    {
        var key = $"menu-{isPremium}";
        var menus = await _cachedService.GetListItemAsync(key);

        if(menus == null)
        {
            menus = await _menuRepository.ListMenuAsync(isPremium);
            if(menus.Count > 0)
            {
                await _cachedService.SetListItemAsync(key, menus);
            }
        }

        return menus;
    }
}
