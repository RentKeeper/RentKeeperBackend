using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class UsuarioCreateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Posicao Posicao { get; set; }
    }
}