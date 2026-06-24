using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastruture.Configurations
{
    public class EntregaConfiguration : IEntityTypeConfiguration<Entrega>
    {
        public void Configure(EntityTypeBuilder<Entrega> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CodigoRast)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e => e.Transpotadora)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.SttsEntrega)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.DataEnvio)
                .IsRequired();

            builder.Property(e => e.DataEntrega);

            builder.HasOne(e => e.IdPedidos)
                .WithMany()
                .HasForeignKey(e => e.IdPedido)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
