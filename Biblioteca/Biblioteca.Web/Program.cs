using Biblioteca.Aplicacao.Interfaces;
using Biblioteca.Aplicacao.Services;
using Biblioteca.Dominio.Entities;
using Biblioteca.Dominio.Repositories;
using Biblioteca.Infraestrutura.Context;
using Biblioteca.Infraestrutura.Repositories; // <<< ADICIONE ESTE USING

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração do banco de dados (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaDB")));

// Injeção de dependências
builder.Services.AddScoped<LivroRepository>();
//builder.Services.AddScoped<GenericRepository<>>(); // caso use genéricos
builder.Services.AddScoped<IGenericRepository<Autor>, GenericRepository<Autor>>();
builder.Services.AddScoped<IGenericRepository<Livro>, LivroRepository>(); // Usa a implementação específica
builder.Services.AddScoped<ILivroService, LivroService>();
// Se você tiver serviços de aplicação, adicione aqui também

var app = builder.Build();

// Configure the HTTP request pipeline.
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
