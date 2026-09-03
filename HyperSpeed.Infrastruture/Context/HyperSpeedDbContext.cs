using HyperSpeed.Domain.Entities;
using HyperSpeed.Infrastruture.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastruture.Context
{
    public class HyperSpeedDbContext : IdentityDbContext

    {
        public HyperSpeedDbContext(DbContextOptions<HyperSpeedDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriasConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            // Configurações adicionais do mode
            // lo podem ser feitas aqui
        }
    }
}