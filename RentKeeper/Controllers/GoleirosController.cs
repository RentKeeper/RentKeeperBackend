using Microsoft.AspNetCore.Mvc;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoleiroController : ControllerBase
    {
        private readonly IGoleiroService _goleiroService;

        public GoleiroController(IGoleiroService goleiroService)
        {
            _goleiroService = goleiroService;
        }

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_goleiroService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var goleiro = _goleiroService.GetById(id);
            if (goleiro == null)
                return NotFound();

            return Ok(goleiro);
        }

        [HttpPost]
        public IActionResult Create([FromBody] GoleiroDto dto)
        {
            var goleiro = _goleiroService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = goleiro.Id }, goleiro);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GoleiroDto dto)
        {
            var goleiro = _goleiroService.Update(id, dto);
            if (goleiro == null)
                return NotFound();

            return Ok(goleiro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _goleiroService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
