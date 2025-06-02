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
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _service;
        private readonly IMapper _mapper;

        public TimeController(ITimeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TimeReadDto>> Create(TimeCreateDto dto)
        {
            var time = _mapper.Map<Time>(dto);
            await _service.CreateAsync(time);
            var read = _mapper.Map<TimeReadDto>(time);
            return CreatedAtAction(nameof(GetById), new { id = read.IdTime }, read);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeReadDto>> GetById(int id)
        {
            var t = await _service.GetByIdAsync(id);
            if (t == null) return NotFound();
            return Ok(_mapper.Map<TimeReadDto>(t));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeReadDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(_mapper.Map<IEnumerable<TimeReadDto>>(list));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReadDto>> Update(int id, TimeCreateDto dto)
        {
            var time = _mapper.Map<Time>(dto);
            var upd = await _service.UpdateAsync(id, time);
            return Ok(_mapper.Map<TimeReadDto>(upd));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
