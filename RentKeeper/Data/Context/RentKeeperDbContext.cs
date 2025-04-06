using Microsoft.EntityFrameworkCore;
using RentKeeper.Models;

namespace RentKeeper.Data.Context
{
    public class RentKeeperDbContext : DbContext
    {
        public RentKeeperDbContext(DbContextOptions<RentKeeperDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Goleiro> Goleiros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
