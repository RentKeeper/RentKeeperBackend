using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RentKeeper.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _service;
        private readonly IMapper _mapper;

        public AluguelController(IAluguelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AluguelDto>> Create(AluguelDto dto)
        {
            var aluguel = _mapper.Map<Aluguel>(dto);
            await _service.CreateAsync(aluguel);
            var read = _mapper.Map<AluguelDto>(aluguel);
            return CreatedAtAction(nameof(GetById), new { id = read.IdAluguel }, read);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AluguelDto>> GetById(int id)
        {
            var al = await _service.GetByIdAsync(id);
            if (al == null) return NotFound();
            return Ok(_mapper.Map<AluguelDto>(al));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AluguelDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(_mapper.Map<IEnumerable<AluguelDto>>(list));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AluguelDto>> Update(int id, AluguelDto dto)
        {
            var aluguel = _mapper.Map<Aluguel>(dto);
            var upd = await _service.UpdateAsync(id, aluguel);
            return Ok(_mapper.Map<AluguelDto>(upd));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
