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
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _service;
        private readonly IMapper _mapper;

        public AnuncioController(IAnuncioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AnuncioDto>> Create(AnuncioDto dto)
        {
            var anuncio = _mapper.Map<Anuncio>(dto);
            await _service.CreateAsync(anuncio);
            var readDto = _mapper.Map<AnuncioDto>(anuncio);
            return CreatedAtAction(nameof(GetById), new { id = readDto.IdAnuncio }, readDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnuncioDto>> GetById(int id)
        {
            var anuncio = await _service.GetByIdAsync(id);
            if (anuncio == null) return NotFound();
            return Ok(_mapper.Map<AnuncioDto>(anuncio));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnuncioDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(_mapper.Map<IEnumerable<AnuncioDto>>(list));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnuncioDto>> Update(int id, AnuncioDto dto)
        {
            var anuncio = _mapper.Map<Anuncio>(dto);
            var updated = await _service.UpdateAsync(id, anuncio);
            return Ok(_mapper.Map<AnuncioDto>(updated));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
