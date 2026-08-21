using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces; 
using hyperSpeed.Application.Services;
using HyperSpeed.Domain.interfaces;
using HyperSpeed.Infrastructure.Repositories;
using HyperSpeed.Infrastruture.Context;
using HyperSpeed.Infrastruture.Identity;
using HyperSpeed.Infrastruture.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// SERVICES
// ===============================

builder.Services.AddDbContext<HyperSpeedDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<HyperSpeedDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };

    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriasRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();

// Web + API
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HyperSpeed API",
        Version = "v1",
        Description = "API REST do sistema HyperSpeed"
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// ===============================
// BUILD
// ===============================

var app = builder.Build();


// ===============================
// PIPELINE
// ===============================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();


// ===============================
// ROTAS
// ===============================
app.MapControllers();
app.MapRazorPages();


// ===============================
// SEED
// ===============================

await SeedData.SeedAsync(app.Services);

app.Run();
