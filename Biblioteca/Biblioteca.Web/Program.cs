using Biblioteca.Aplicacao.Interfaces;
using Biblioteca.Aplicacao.Services;
using Biblioteca.Dominio.Entities;
using Biblioteca.Dominio.Repositories;
using Biblioteca.Infraestrutura.Context;
using Biblioteca.Infraestrutura.Repositories; 

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaDB")));

builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<IGenericRepository<Autor>, GenericRepository<Autor>>();
builder.Services.AddScoped<IGenericRepository<Livro>, LivroRepository>(); // Usa a implementação específica
builder.Services.AddScoped<ILivroService, LivroService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Livro}/{action=Index}/{id?}");

app.Run();
