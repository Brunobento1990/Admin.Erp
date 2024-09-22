using Admin.Erp.Domain.Entities.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class MenuRotaConfiguration : BaseEntityConfiguration<MenuRota>
{
    public override void Configure(EntityTypeBuilder<MenuRota> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Rota)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(x => x.Menu)
            .WithMany(x => x.MenuRotas)
            .HasForeignKey(x => x.MenuId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
