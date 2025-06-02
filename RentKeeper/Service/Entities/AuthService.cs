using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentKeeper.Data.Context;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
	public class AuthService : IAuthService
	{
		private readonly RentKeeperDbContext _context;
		private readonly IConfiguration _configuration;

		public AuthService(RentKeeperDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public async Task<bool> ValidarCredenciaisAsync(string email, string senha)
		{
			// OBS: Em produção, armazene senhas com hash e NÃO em texto puro.
			var usuario = await _context.Usuarios
				.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

			return usuario != null;
		}

		public async Task<int?> ObterUsuarioIdPorEmail(string email)
		{
			var usuario = await _context.Usuarios
				.FirstOrDefaultAsync(u => u.Email == email);

			return usuario?.Id;
		}

		public string GerarToken(int usuarioId, string email)
		{
			// 1. Recupera configurações do JWT do appsettings.json
			var keyString = _configuration["Jwt:Key"]!;
			var issuer = _configuration["Jwt:Issuer"]!;
			var audience = _configuration["Jwt:Audience"]!;

			// 2. Cria a chave de segurança
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			// 3. Define reclamações (claims) — precisamos do Id e e-mail
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, usuarioId.ToString()),
				new Claim(JwtRegisteredClaimNames.Email, email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			// 4. Cria o token
			var token = new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims: claims,
				expires: DateTime.UtcNow.AddHours(2),
				signingCredentials: creds
			);

			// 5. Retorna token serializado
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
