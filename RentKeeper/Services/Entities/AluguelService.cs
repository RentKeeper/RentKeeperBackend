using RentKeeper.Data.Interfaces;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Services.Interfaces;
using AutoMapper;

namespace RentKeeper.Services.Entities
{
    public class AluguelService : IAluguelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AluguelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Aluguel> GetAll()
        {
            return _unitOfWork.Alugueis.GetAllAsync().Result;
        }

        public Aluguel? GetById(int id)
        {
            return _unitOfWork.Alugueis.GetByIdAsync(id).Result;
        }

        public Aluguel Create(AluguelDto dto)
        {
            var aluguel = _mapper.Map<Aluguel>(dto);
            _unitOfWork.Alugueis.AddAsync(aluguel).Wait();
            _unitOfWork.SaveChangesAsync().Wait();
            return aluguel;
        }

        public Aluguel? Update(int id, AluguelDto dto)
        {
            var aluguel = _unitOfWork.Alugueis.GetByIdAsync(id).Result;
            if (aluguel == null) return null;

            _mapper.Map(dto, aluguel);
            _unitOfWork.Alugueis.Update(aluguel);
            _unitOfWork.SaveChangesAsync().Wait();
            return aluguel;
        }

        public bool Delete(int id)
        {
            var aluguel = _unitOfWork.Alugueis.GetByIdAsync(id).Result;
            if (aluguel == null) return false;

            _unitOfWork.Alugueis.Delete(aluguel);
            _unitOfWork.SaveChangesAsync().Wait();
            return true;
        }
    }
}
