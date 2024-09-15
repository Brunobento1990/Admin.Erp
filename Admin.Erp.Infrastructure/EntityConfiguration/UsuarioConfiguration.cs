using Admin.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class UsuarioConfiguration : BaseEntityPessoaConfiguration<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(1000);
        base.Configure(builder);
    }
}
