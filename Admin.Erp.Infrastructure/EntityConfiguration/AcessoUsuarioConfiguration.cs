using Admin.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal class AcessoUsuarioConfiguration : BaseEntityConfiguration<AcessoUsuario>
{
    public override void Configure(EntityTypeBuilder<AcessoUsuario> builder)
    {
        builder.HasIndex(x => x.TokenEsqueceuSenha);
        builder.HasIndex(x => x.Bloqueado);

        builder.HasOne(x => x.Usuario)
            .WithOne(x => x.AcessoUsuario)
            .HasForeignKey<AcessoUsuario>(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}
