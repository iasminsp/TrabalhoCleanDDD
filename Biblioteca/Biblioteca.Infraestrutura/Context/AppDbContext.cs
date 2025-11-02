using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio.Entities; 

namespace Biblioteca.Infraestrutura.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
