using Admin.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class UsuarioConfiguration : BaseEntityPessoaConfiguration<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(x => x.PerfilUsuario)
            .WithMany(x => x.Usuarios)
            .HasForeignKey(x => x.PerfilUsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
