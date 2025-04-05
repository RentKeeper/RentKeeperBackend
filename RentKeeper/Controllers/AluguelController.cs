using Microsoft.AspNetCore.Mvc;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _aluguelService;

        public AluguelController(IAluguelService aluguelService)
        {
            _aluguelService = aluguelService;
        }

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_aluguelService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluguel = _aluguelService.GetById(id);
            if (aluguel == null)
                return NotFound();

            return Ok(aluguel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AluguelDto dto)
        {
            var aluguel = _aluguelService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = aluguel.IdAluguel }, aluguel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AluguelDto dto)
        {
            var aluguel = _aluguelService.Update(id, dto);
            if (aluguel == null)
                return NotFound();

            return Ok(aluguel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _aluguelService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
