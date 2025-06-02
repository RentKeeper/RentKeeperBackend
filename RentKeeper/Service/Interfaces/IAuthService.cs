using System.Threading.Tasks;

namespace RentKeeper.Services.Interfaces
{
	/// <summary>
	/// Interface para manipular autenticação e geração de token JWT.
	/// </summary>
	public interface IAuthService
	{
		/// <summary>
		/// Valida se as credenciais (e-mail e senha) estão corretas.
		/// </summary>
		Task<bool> ValidarCredenciaisAsync(string email, string senha);

		/// <summary>
		/// Retorna o Id do usuário a partir do e-mail, se existir.
		/// </summary>
		Task<int?> ObterUsuarioIdPorEmail(string email);

		/// <summary>
		/// Gera um token JWT com base no Id e e-mail do usuário.
		/// </summary>
		string GerarToken(int usuarioId, string email);
	}
}
