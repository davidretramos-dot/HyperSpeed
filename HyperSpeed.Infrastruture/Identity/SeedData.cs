using HyperSpeed.Domain.Entities;
using HyperSpeed.Infrastruture.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HyperSpeed.Infrastruture.Identity
{
    public static class SeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HyperSpeedDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); ;

            await context.Database.MigrateAsync();

            if (!context.Categorias.Any())
            {
                var categorias = new List<Categorias>
    {
        new Categorias { Nome = "Processadores" },
        new Categorias { Nome = "Placas de Vídeo" },
        new Categorias{ Nome = "SSD" },
        new Categorias{ Nome = "Teclados" },
        new Categorias { Nome = "Placas-Mãe" },
        new Categorias { Nome = "Headsets e Fones" },
        new Categorias { Nome = "Controles" },
        new Categorias { Nome = "Iluminação RGB" },
        new Categorias { Nome = "Monitores" },
        new Categorias { Nome = "Gabinetes" },
        new Categorias { Nome = "Mouses" },
        new Categorias { Nome = "Notebooks" },
        new Categorias { Nome = "Mesas" }
    };

                await context.Categorias.AddRangeAsync(categorias);
                await context.SaveChangesAsync();


            }
            var processadores = await context.Categorias.FirstAsync(x => x.Nome == "Processadores");
            var placasVideo = await context.Categorias.FirstAsync(x => x.Nome == "Placas de Vídeo");
            var ssd = await context.Categorias.FirstAsync(x => x.Nome == "SSD");
            var teclados = await context.Categorias.FirstAsync(x => x.Nome == "Teclados");
            var placasMae = await context.Categorias.FirstAsync(x => x.Nome == "Placas-Mãe");
            var headsets = await context.Categorias.FirstAsync(x => x.Nome == "Headsets e Fones");
            var controles = await context.Categorias.FirstAsync(x => x.Nome == "Controles");
            var rgb = await context.Categorias.FirstAsync(x => x.Nome == "Iluminação RGB");
            var monitores = await context.Categorias.FirstAsync(x => x.Nome == "Monitores");
            var gabinetes = await context.Categorias.FirstAsync(x => x.Nome == "Gabinetes");
            var mouses = await context.Categorias.FirstAsync(x => x.Nome == "Mouses");
            var notebooks = await context.Categorias.FirstAsync(x => x.Nome == "Notebooks");
            var mesas = await context.Categorias.FirstAsync(x => x.Nome == "Mesas");
            if (!context.Produtos.Any())
            {
                var produtos = new List<Produto>
    {
        new Produto
        {
            Nome = "AMD Ryzen 5 5600X",
            Descricao = "Processador AMD Ryzen 5 6 núcleos",
            Imagem = "...",
            Preco = 899.90m,
            Estoque = 50,
            IdCategoria = processadores.Id
        },

        new Produto
        {
            Nome = "RTX 4070 12GB",
            Descricao = "Placa de vídeo NVIDIA RTX 4070",
            Imagem = "...",
            Preco = 3899.90m,
            Estoque = 20,
            IdCategoria = placasVideo.Id
        },

        new Produto
        {
            Nome = "SSD NVMe 1TB",
            Descricao = "SSD M.2 NVMe Gen4 1TB",
            Imagem = "...",
            Preco = 429.90m,
            Estoque = 80,
            IdCategoria = ssd.Id
        },

        new Produto
        {
            Nome = "Teclado Mecânico RGB",
            Descricao = "Teclado mecânico gamer RGB",
            Imagem = "...",
            Preco = 249.90m,
            Estoque = 60,
            IdCategoria = teclados.Id
        },


    };

                await context.Produtos.AddRangeAsync(produtos);
                await context.SaveChangesAsync();
            }

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

