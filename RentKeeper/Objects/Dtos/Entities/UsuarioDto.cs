using System.ComponentModel.DataAnnotations;
using RentKeeper.Models;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class UsuarioDto
    {
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }

        [Range(1, 3, ErrorMessage = "Role deve ser entre 1 (Goleiro), 2 (Admin) ou 3 (Cliente).")]
        public RoleUsuario Role { get; set; }

    }
}
