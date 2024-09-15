using Admin.Erp.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Erp.Infrastructure.EntityConfiguration;

internal abstract class BaseEntityPessoaConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntityPessoa
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CriadoEm)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("now()");
        builder.Property(x => x.AtualizadoEm)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("now()");
        builder.Property(x => x.EmpresaId)
            .IsRequired();
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Cpf)
            .HasMaxLength(11);

        builder.HasGeneratedTsVectorColumn(
                   p => p.Search,
                   config: "portuguese",
                   p => new { p.Nome, p.Cpf })
               .HasIndex(p => p.Search)
               .HasMethod("GIN");

        builder.HasIndex(x => x.EmpresaId);
        builder.HasIndex(x => x.Nome);
        builder.HasIndex(x => x.Cpf);
    }
}
