using Admin.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class EmpresaConfiguration : BaseEntityConfiguration<Empresa>
{
    public override void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.Property(x => x.RazaoSocial)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.NomeFantasia)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Cnpj)
            .IsRequired()
            .HasMaxLength(14);
        builder.Property(x => x.Premium)
            .IsRequired();

        base.Configure(builder);
    }
}
