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

        // Exemplo: adicione mais DbSets quando necessário
        // public DbSet<Jogador> Jogadores { get; set; }
        // public DbSet<Partida> Partidas { get; set; }
    }
}
