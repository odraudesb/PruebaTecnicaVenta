using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
