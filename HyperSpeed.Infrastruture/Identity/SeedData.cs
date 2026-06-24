using HyperSpeed.Domain.Entities;
using HyperSpeed.Infrastruture.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastruture.Identity
{
    public static class SeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HyperSpeedDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();


            //Seed de categorias    
            if (!context.Categorias.Any())
            {
                var cat = new List<Categorias>
                {
                    new Categorias { Nome = " Hardware" },
                    new Categorias { Nome = " Computadores" },
                    new Categorias { Nome = " Periféricos" },
                    new Categorias { Nome = " Equipamentos" },

                };
                await context.Categorias.AddRangeAsync(cat);
                await context.SaveChangesAsync();

            }
            if (!context.Produtos.Any())
            {
                var hardware = await context.Categorias.FirstAsync(c=> c.Nome =="Hardware");
                var compuiter = await context.Categorias.FirstAsync(c=> c.Nome =="Computadores");
                var Perifericos = await context.Categorias.FirstAsync(c=> c.Nome =="Periféricos");
                var equip = await context.Categorias.FirstAsync(c=> c.Nome =="Equipamentos");
                var produtos = new List<Produto>
{
    // Monte seu PC

    new Produto
    {
        Nome = "AMD Ryzen 5 5600X",
        Descricao = "Processador AMD Ryzen 5 6 núcleos",
        Preco = 899.90m,
        Estoque = 50,
        IdCategoria = 1
    },

    new Produto
    {
        Nome = "RTX 4070 12GB",
        Descricao = "Placa de vídeo NVIDIA RTX 4070",
        Preco = 3899.90m,
        Estoque = 20,
        IdCategoria = 2
    },

    new Produto
    {
        Nome = "SSD NVMe 1TB",
        Descricao = "SSD M.2 NVMe Gen4 1TB",
        Preco = 429.90m,
        Estoque = 80,
        IdCategoria = 3
    },

    new Produto
    {
        Nome = "Intel Core i5 14600K",
        Descricao = "Processador Intel Core i5 14ª geração",
        Preco = 1499.90m,
        Estoque = 30,
        IdCategoria = 1
    },

    // Periféricos

    new Produto
    {
        Nome = "Teclado Mecânico RGB",
        Descricao = "Teclado mecânico gamer RGB",
        Preco = 249.90m,
        Estoque = 60,
        IdCategoria = 4
    },

    new Produto
    {
        Nome = "Placa-Mãe B550",
        Descricao = "Placa-mãe AM4 chipset B550",
        Preco = 699.90m,
        Estoque = 25,
        IdCategoria = 5
    },

    new Produto
    {
        Nome = "Headset Gamer",
        Descricao = "Headset com microfone",
        Preco = 189.90m,
        Estoque = 40,
        IdCategoria = 6
    },

    new Produto
    {
        Nome = "Controle Gamer USB",
        Descricao = "Controle para PC",
        Preco = 149.90m,
        Estoque = 35,
        IdCategoria= 7
    },

    new Produto
    {
        Nome = "Fita LED RGB",
        Descricao = "Iluminação RGB para setup",
        Preco = 79.90m,
        Estoque = 100,
        IdCategoria = 8
    },

    new Produto
    {
        Nome = "Fone Bluetooth",
        Descricao = "Fone sem fio bluetooth",
        Preco = 229.90m,
        Estoque = 45,
        IdCategoria = 6
    },

    new Produto
    {
        Nome = "Monitor Gamer 27 Pol",
        Descricao = "Monitor Full HD 165Hz",
        Preco = 1199.90m,
        Estoque = 15,
        IdCategoria = 9
    },

    new Produto
    {
        Nome = "Teclado Compacto RGB",
        Descricao = "Teclado mecânico compacto",
        Preco = 199.90m,
        Estoque = 50,
        IdCategoria = 4
    },

    new Produto
    {
        Nome = "Gabinete Mid Tower",
        Descricao = "Gabinete gamer com vidro lateral",
        Preco = 349.90m,
        Estoque = 22,
        IdCategoria = 10
    },

    new Produto
    {
        Nome = "Mouse Gamer RGB",
        Descricao = "Mouse gamer 7200 DPI",
        Preco = 99.90m,
        Estoque = 75,
        IdCategoria = 11
    },

    new Produto
    {
        Nome = "Notebook ASUS Vivobook",
        Descricao = "Notebook para estudo e trabalho",
        Preco = 3299.90m,
        Estoque = 12,
        IdCategoria = 12
    },

    new Produto
    {
        Nome = "Mesa Gamer",
        Descricao = "Mesa gamer 120cm",
        Preco = 599.90m,
        Estoque = 10,
        IdCategoria = 13
    }
};
                var categorias = new List<Categorias>
{
    new Categorias { Id = 1, Nome = "Processadores" },
    new Categorias { Id = 2, Nome = "Placas de Vídeo" },
    new Categorias { Id = 3, Nome = "SSD" },
    new Categorias { Id = 4, Nome = "Teclados" },
    new Categorias { Id = 5, Nome = "Placas-Mãe" },
    new Categorias { Id = 6, Nome = "Headsets e Fones" },
    new Categorias { Id = 7, Nome = "Controles" },
    new Categorias { Id = 8, Nome = "Iluminação RGB" },
    new Categorias { Id = 9, Nome = "Monitores" },
    new Categorias { Id = 10, Nome = "Gabinetes" },
    new Categorias { Id = 11, Nome = "Mouses" },
    new Categorias { Id = 12, Nome = "Notebooks" },
    new Categorias { Id = 13, Nome = "Mesas" }
};
            }
        }
    }
}

