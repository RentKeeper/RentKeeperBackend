using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioReadDto>> Create(UsuarioCreateDto )
        {
            var usuario = _mapper.Map<Usuario>(dto);
            await _service.CreateAsync(usuario);
            var readDto = _mapper.Map<UsuarioReadDto>(usuario);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(_mapper.Map<UsuarioReadDto>(usuario));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(_mapper.Map<IEnumerable<UsuarioReadDto>>(list));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> Update(int id, UsuarioCreateDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var updated = await _service.UpdateAsync(id, usuario);
            return Ok(_mapper.Map<UsuarioReadDto>(updated));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}