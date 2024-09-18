using Admin.Erp.Domain.Entities.Global;

namespace Admin.Erp.Application.ViewModel;

public class MenuViewModel
{
    public Guid Id { get; set; }
    public string Path { get; set; } = string.Empty;
    public string? Icone { get; set; }
    public int Ordem { get; set; }
    public IList<MenuViewModel> Filhos { get; set; } = [];

    public static explicit operator MenuViewModel(Menu menu)
    {
        return new MenuViewModel()
        {
            Id = menu.Id,
            Path = menu.Path,
            Icone = menu.Icone,
            Ordem = menu.Ordem
        };
    }
}
