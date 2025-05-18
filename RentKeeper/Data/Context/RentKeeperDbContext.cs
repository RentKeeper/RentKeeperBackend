using Microsoft.EntityFrameworkCore;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Context
{
    public class RentKeeperDbContext : DbContext
    {
        public RentKeeperDbContext(DbContextOptions<RentKeeperDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        // Futuras entidades: Anuncios, Alugueis, Pagamentos, Times...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Registrar Builders
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentKeeperDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}