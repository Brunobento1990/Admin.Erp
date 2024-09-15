using Admin.Erp.Domain.Entities;
using Admin.Erp.Domain.Entities.Global;
using Admin.Erp.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Admin.Erp.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new MenuConfiguration());
    }
}
