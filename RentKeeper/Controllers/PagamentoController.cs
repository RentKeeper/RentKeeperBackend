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
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _service;
        private readonly IMapper _mapper;

        public PagamentoController(IPagamentoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PagamentoDto>> Create(PagamentoDto dto)
        {
            var pag = _mapper.Map<Pagamento>(dto);
            await _service.CreateAsync(pag);
            var read = _mapper.Map<PagamentoDto>(pag);
            return CreatedAtAction(nameof(GetById), new { id = read.IdPagamento }, read);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagamentoDto>> GetById(int id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return Ok(_mapper.Map<PagamentoDto>(p));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(_mapper.Map<IEnumerable<PagamentoDto>>(list));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PagamentoDto>> Update(int id, PagamentoDto dto)
        {
            var pag = _mapper.Map<Pagamento>(dto);
            var upd = await _service.UpdateAsync(id, pag);
            return Ok(_mapper.Map<PagamentoDto>(upd));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
