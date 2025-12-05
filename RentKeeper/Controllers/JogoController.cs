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
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _service;
        private readonly IMapper _mapper;

        public JogoController(IJogoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<JogoDto>> Create(JogoDto dto)
        {
            if (dto.TimeMandanteId == dto.TimeVisitanteId)
            {
                ModelState.AddModelError(nameof(dto.TimeVisitanteId), "O time adversário deve ser diferente do time mandante.");
                return ValidationProblem(ModelState);
            }

            var entity = _mapper.Map<Jogo>(dto);

            try
            {
                await _service.CreateAsync(entity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            var created = await _service.GetByIdAsync(entity.IdJogo) ?? entity;
            var readDto = _mapper.Map<JogoDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = readDto.IdJogo }, readDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(_mapper.Map<IEnumerable<JogoDto>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JogoDto>> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JogoDto>(entity));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JogoDto>> Update(int id, JogoDto dto)
        {
            if (dto.TimeMandanteId == dto.TimeVisitanteId)
            {
                ModelState.AddModelError(nameof(dto.TimeVisitanteId), "O time adversário deve ser diferente do time mandante.");
                return ValidationProblem(ModelState);
            }

            var entity = _mapper.Map<Jogo>(dto);
            Jogo updated;
            try
            {
                updated = await _service.UpdateAsync(id, entity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            var reloaded = await _service.GetByIdAsync(updated.IdJogo) ?? updated;
            return Ok(_mapper.Map<JogoDto>(reloaded));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
