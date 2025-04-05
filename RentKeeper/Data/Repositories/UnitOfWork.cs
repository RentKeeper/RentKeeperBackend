using RentKeeper.Data.Interfaces;
using RentKeeper.Models;
using RentKeeper.Data.Context;

namespace RentKeeper.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentKeeperDbContext _context;

        public IGenericRepository<Aluguel> Alugueis { get; }

        // Adiciona aqui depois conforme crescer:
        // public IGenericRepository<Jogador> Jogadores { get; }
        // public IGenericRepository<Partida> Partidas { get; }

        public UnitOfWork(RentKeeperDbContext context)
        {
            _context = context;
            Alugueis = new GenericRepository<Aluguel>(_context);

            // Jogadores = new GenericRepository<Jogador>(_context);
            // Partidas = new GenericRepository<Partida>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
