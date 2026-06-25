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
                var hardware = await context.Categorias.FirstAsync(c => c.Nome == "Hardware");
                var compuiter = await context.Categorias.FirstAsync(c => c.Nome == "Computadores");
                var Perifericos = await context.Categorias.FirstAsync(c => c.Nome == "Periféricos");
                var equip = await context.Categorias.FirstAsync(c => c.Nome == "Equipamentos");
                var produtos = new List<Produto>
{
    // Monte seu PC

    new Produto
    {
        Nome = "AMD Ryzen 5 5600X",
        Descricao = "Processador AMD Ryzen 5 6 núcleos",
        Imagem ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzynv-zHvncG_VVEGYv_j91-t1EE4Qni51xA&s",
        Preco = 899.90m,
        Estoque = 50,
        IdCategoria = 1
    },

    new Produto
    {
        Nome = "RTX 4070 12GB",
        Descricao = "Placa de vídeo NVIDIA RTX 4070",
        Imagem ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAs_dPF9BztTLx3AhxcKky9zDCD1x9bHfzCg&s",
        Preco = 3899.90m,
        Estoque = 20,
        IdCategoria = 2
    },

    new Produto
    {
        Nome = "SSD NVMe 1TB",
        Descricao = "SSD M.2 NVMe Gen4 1TB",
        Imagem ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQquhHE-dQIlIV_Tz46nn92H7VnGm4RiMCCWw&s",
        Preco = 429.90m,
        Estoque = 80,
        IdCategoria = 3
    },

    new Produto
    {
        Nome = "Intel Core i5 14600K",
        Descricao = "Processador Intel Core i5 14ª geração",
        Imagem ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnZjDdYApUS2H8MZYIU_NHdtRSYKhj34v-6A&s",
        Preco = 1499.90m,
        Estoque = 30,
        IdCategoria = 1
    },

    // Periféricos

    new Produto
    {
        Nome = "Teclado Mecânico RGB",
        Descricao = "Teclado mecânico gamer RGB",
        Imagem ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJ_3cCKaHFJ_wNfAYZsXgcCqf89h_RYNBkSg&s",
        Preco = 249.90m,
        Estoque = 60,
        IdCategoria = 4
    },

    new Produto
    {
        Nome = "Placa-Mãe B550",
        Descricao = "Placa-mãe AM4 chipset B550",
        Imagem="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQURVolth8dvt1Fm3S48RfKo5JuWEQ7j1hSTA&s",
        Preco = 699.90m,
        Estoque = 25,
        IdCategoria = 5
    },

    new Produto
    {
        Nome = "Headset Gamer",
        Descricao = "Headset com microfone",
        Imagem="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3oV6AbBM9sJlBAjDmCYw_sUht_JtELuYT0w&s",
        Preco = 189.90m,
        Estoque = 40,
        IdCategoria = 6
    },

    new Produto
    {
        Nome = "Controle Gamer USB",
        Descricao = "Controle para PC",
        Imagem="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS986DtLVafG9jwUTxl6wDkc14Ny1WaHQRqng&s",
        Preco = 149.90m,
        Estoque = 35,
        IdCategoria= 7
    },

    new Produto
    {
        Nome = "Fita LED RGB",
        Descricao = "Iluminação RGB para setup",
        Imagem="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTf1Ye-yvnjborPGxAaRmVjwSfONx8322fodA&s",
        Preco = 79.90m,
        Estoque = 100,
        IdCategoria = 8
    },

    new Produto
    {
        Nome = "Fone Bluetooth",
        Descricao = "Fone sem fio bluetooth",
        Imagem ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUNY-Z6h--CCAzoPP2JQ-x4SPY-kgZtPK85w&s",
        Preco = 229.90m,
        Estoque = 45,
        IdCategoria = 6
    },

    new Produto
    {
        Nome = "Monitor Gamer 27 Pol",
        Descricao = "Monitor Full HD 165Hz",
        Imagem="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTotD02X0WhVUTNloiuQ1CKRWqDyEjtF7tvGQ&s",
        Preco = 1199.90m,
        Estoque = 15,
        IdCategoria = 9
    },

    new Produto
    {
        Nome = "Teclado Compacto RGB",
        Descricao = "Teclado mecânico compacto",
        Imagem="https://m.media-amazon.com/images/I/71f3AEF9+lL._AC_UF894,1000_QL80_.jpg",
        Preco = 199.90m,
        Estoque = 50,
        IdCategoria = 4
    },

    new Produto
    {
        Nome = "Gabinete Mid Tower",
        Descricao = "Gabinete gamer com vidro lateral",
        Imagem ="https://img.terabyteshop.com.br/produto/g/gabinete-gamer-montech-xr-mid-tower-black-atx-com-3-fans-vidro-temperado-xr-b_206259.jpg",
        Preco = 349.90m,
        Estoque = 22,
        IdCategoria = 10
    },

    new Produto
    {
        Nome = "Mouse Gamer RGB",
        Descricao = "Mouse gamer 7200 DPI",
        Imagem ="https://cdn.awsli.com.br/2500x2500/1318/1318167/produto/373743013/m991-rgb-1-7a89vvqfqv.jpg",
        Preco = 99.90m,
        Estoque = 75,
        IdCategoria = 11
    },

    new Produto
    {
        Nome = "Notebook ASUS Vivobook",
        Descricao = "Notebook para estudo e trabalho",
        Imagem="https://m.media-amazon.com/images/I/71iESqOEpeL._AC_UF894,1000_QL80_.jpg",
        Preco = 3299.90m,
        Estoque = 12,
        IdCategoria = 12
    },

    new Produto
    {
        Nome = "Mesa Gamer",
        Descricao = "Mesa gamer 120cm",
        Imagem ="https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcS_0Wfi5deFHCZtloH2FxtAlFtktlXNTqA8D0ZuvX-8T5gUrQhumaOI5mNadcyE4xiJc2jgEcpoFh8iGkciA6rZcQwS8otbphTYHcjRzLeQWVX7dBlFwPkKO76A8v_1u7awoPNPqoYiCA8&usqp=CAc",
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
                await context.Produtos.AddRangeAsync(produtos);
                await context.SaveChangesAsync();


                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                var AdminEmail = "adminHS@gmail.com";
                var AdminUser = await userManager.FindByEmailAsync(AdminEmail);

                if (AdminUser == null)
                {
                    AdminUser = new IdentityUser
                    {
                        UserName = AdminEmail,
                        Email = AdminEmail,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(AdminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(AdminUser, "Admin");
                    }
                }
            }
        }
    }
}

