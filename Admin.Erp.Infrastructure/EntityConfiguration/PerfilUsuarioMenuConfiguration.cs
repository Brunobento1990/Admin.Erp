using Admin.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class PerfilUsuarioMenuConfiguration : IEntityTypeConfiguration<PerfilUsuarioMenu>
{
    public void Configure(EntityTypeBuilder<PerfilUsuarioMenu> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Menu)
            .WithOne(x => x.PerfilUsuarioMenu)
            .HasForeignKey<PerfilUsuarioMenu>(x => x.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PerfilUsuario)
            .WithMany(x => x.PerfilUsuarioMenu)
            .HasForeignKey(x => x.PerfilUsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
