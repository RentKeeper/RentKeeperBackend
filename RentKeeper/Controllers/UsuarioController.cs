
using Microsoft.AspNetCore.Mvc;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        
        public IActionResult Create([FromBody] UsuarioDto dto)
        {
            try
            {
                var usuario = _usuarioService.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UsuarioDto dto)
        {
            try
            {
                var usuario = _usuarioService.Update(id, dto);
                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _usuarioService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
