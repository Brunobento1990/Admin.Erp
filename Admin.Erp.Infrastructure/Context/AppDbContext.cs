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
    public DbSet<MenuRota> MenuRotas { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
    public DbSet<PerfilUsuarioMenu> PerfilUsuarioMenus { get; set; }
    public DbSet<PerfilUsuarioMenuRota> PerfilUsuarioMenuRotas { get; set; }
    public DbSet<AcessoUsuario> AcessosUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PerfilUsuarioMenuConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilUsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new MenuRotaConfiguration());
        modelBuilder.ApplyConfiguration(new AcessoUsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new MenuConfiguration());
    }
}
