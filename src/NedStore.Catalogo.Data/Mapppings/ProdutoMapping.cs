using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NedStore.Catalogo.Data.Mapppings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired().HasColumnType("varchar(250)");

            builder.Property(p => p.Descricao)
                .IsRequired().HasColumnType("varchar(500)");

            builder.Property(p => p.Imagem)
                .IsRequired().HasColumnType("varchar(250)");


            builder.OwnsOne(p => p.Dimensoes, cm =>
            {
                cm.Property(c => c.Altura)
                  .HasColumnName("Altura")
                  .HasColumnType("int");

                cm.Property(c => c.Largura)
                  .HasColumnName("Largura")
                  .HasColumnType("int");

                cm.Property(c => c.Profundidade)
                  .HasColumnName("Profundidade")
                  .HasColumnType("int");
            });

            builder.ToTable("Produtos");
        }
    }
}
