using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

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

		// POST /api/Usuario
		[AllowAnonymous] // Se quiser que o cadastro seja público (sem JWT)
		[HttpPost]
		public async Task<ActionResult<UsuarioDto>> Create([FromBody] UsuarioDto dto)
		{
			// 'dto' está declarado como parâmetro aqui
			var usuarioModel = _mapper.Map<Usuario>(dto);
			var createdUsuario = await _service.CreateAsync(usuarioModel);

			var readDto = _mapper.Map<UsuarioDto>(createdUsuario);
			return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
		}

		// GET /api/Usuario/{id}
		[AllowAnonymous] // Pode ou não proteger, dependendo da sua regra
		[HttpGet("{id}")]
		public async Task<ActionResult<UsuarioDto>> GetById(int id)
		{
			var usuario = await _service.GetByIdAsync(id);
			if (usuario == null) return NotFound();

			var readDto = _mapper.Map<UsuarioDto>(usuario);
			return Ok(readDto);
		}

		// GET /api/Usuario?page=1&pageSize=10
		[AllowAnonymous]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
		{
			var usuarios = await _service.GetAllAsync(page, pageSize);
			var readDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
			return Ok(readDtos);
		}

		// PUT /api/Usuario/{id}
		[Authorize] // Exige token válido para atualizar
		[HttpPut("{id}")]
		public async Task<ActionResult<UsuarioDto>> Update(int id, [FromBody] UsuarioUpdateDto dto)
		{
			var updatedUsuario = await _service.UpdateAsync(id, dto);
			if (updatedUsuario == null) return NotFound();

			var readDto = _mapper.Map<UsuarioDto>(updatedUsuario);
			return Ok(readDto);
		}

		// DELETE /api/Usuario/{id}
		[Authorize]
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}
}
