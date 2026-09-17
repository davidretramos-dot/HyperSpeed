using HyperSpeed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HyperSpeed.Infrastruture.Configurations
{
    public class FavoritoConfiguration : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.UserId)
                .IsRequired();

            builder.HasOne(f => f.Produto)
                .WithMany()
                .HasForeignKey(f => f.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Impede o mesmo usuário de favoritar
            // o mesmo produto duas vezes
            builder.HasIndex(f => new
            {
                f.UserId,
                f.ProdutoId
            })
            .IsUnique();
        }
    }
}