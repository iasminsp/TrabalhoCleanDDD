using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Biblioteca.Infraestrutura.Context;

namespace Biblioteca.Infraestrutura.DesignTime
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=localhost,1433;Database=BibliotecaDB;User Id=sa;Password=Senha@123;TrustServerCertificate=True;");
            return new AppDbContext(builder.Options);
        }
    }
}
