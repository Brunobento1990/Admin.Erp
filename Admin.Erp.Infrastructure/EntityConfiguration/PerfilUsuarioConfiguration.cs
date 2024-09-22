using Admin.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class PerfilUsuarioConfiguration : BaseEntityEmpresaConfiguration<PerfilUsuario>
{
    public override void Configure(EntityTypeBuilder<PerfilUsuario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasMaxLength(255);
    }
}
