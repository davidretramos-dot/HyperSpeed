using HyperSpeed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastruture.Configurations
{
    public class CategoriasConfiguration : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Descricao)
                .HasMaxLength(500);
        }
    }
}
