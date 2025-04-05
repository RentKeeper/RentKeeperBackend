using RentKeeper.Models;

namespace RentKeeper.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Aluguel> Alugueis { get; }

        // Se tiver mais entidades depois:
        // IGenericRepository<Jogador> Jogadores { get; }
        // IGenericRepository<Partida> Partidas { get; }

        Task SaveChangesAsync();
    }
}
