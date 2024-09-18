using Admin.Erp.Domain.Entities.Global;

namespace Admin.Erp.Domain.Interfaces;

public interface IMenuRepository
{
    Task<IList<Menu>> ListMenuAsync(bool isPremium);
}
