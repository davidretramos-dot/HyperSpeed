using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastruture.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TipoPagamento)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.SttsPagamento)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(p => p.Pedido)
                .WithOne()
                .HasForeignKey<Pagamento>(p => p.IdPedido)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
