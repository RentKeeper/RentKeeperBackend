using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RentKeeper.Objects.Dtos.Auth;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		/// <summary>
		/// Endpoint para login de usuário: recebe e-mail e senha, retorna token JWT.
		/// </summary>
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UsuarioLoginDto dto)
		{
			if (!await _authService.ValidarCredenciaisAsync(dto.Email, dto.Senha))
				return Unauthorized(new { mensagem = "Credenciais inválidas." });

			var usuarioId = await _authService.ObterUsuarioIdPorEmail(dto.Email);
			if (usuarioId == null)
				return Unauthorized(new { mensagem = "Usuário não encontrado." });

			var token = _authService.GerarToken(usuarioId.Value, dto.Email);

			return Ok(new { Token = token });
		}
	}
}
