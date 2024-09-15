using Admin.Erp.Domain.Entities.Global;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class MenuConfiguration : BaseEntityConfiguration<Menu>
{
    public override void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(x => x.Icone)
            .HasMaxLength(255);
        builder.Property(x => x.Path)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Ordem)
            .IsRequired();
        builder.Property(x => x.Premium)
            .IsRequired();
        builder.HasIndex(x => x.Ordem);


        base.Configure(builder);
    }
}
