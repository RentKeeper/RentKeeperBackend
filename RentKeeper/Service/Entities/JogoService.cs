using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _repository;
        private readonly ITimeRepository _timeRepository;

        public JogoService(IJogoRepository repository, ITimeRepository timeRepository)
        {
            _repository = repository;
            _timeRepository = timeRepository;
        }

        public async Task<Jogo> CreateAsync(Jogo jogo)
        {
            await EnsureTimesExist(jogo.TimeMandanteId, jogo.TimeVisitanteId);
            await _repository.AddAsync(jogo);
            return jogo;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Jogo>> GetAllAsync(int page, int pageSize)
        {
            return await _repository.GetAllAsync(page, pageSize);
        }

        public async Task<Jogo?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Jogo> UpdateAsync(int id, Jogo jogo)
        {
            jogo.IdJogo = id;
            await EnsureTimesExist(jogo.TimeMandanteId, jogo.TimeVisitanteId);
            await _repository.UpdateAsync(jogo);
            return jogo;
        }

        private async Task EnsureTimesExist(int mandanteId, int visitanteId)
        {
            var mandante = await _timeRepository.GetByIdAsync(mandanteId);
            if (mandante == null)
            {
                throw new KeyNotFoundException($"Time mandante com ID {mandanteId} não encontrado.");
            }

            var visitante = await _timeRepository.GetByIdAsync(visitanteId);
            if (visitante == null)
            {
                throw new KeyNotFoundException($"Time visitante com ID {visitanteId} não encontrado.");
            }
        }
    }
}
