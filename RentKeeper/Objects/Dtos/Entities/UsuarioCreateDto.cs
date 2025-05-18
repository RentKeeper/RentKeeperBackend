using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class UsuarioCreateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Cpf { get; set; }
        public int Telefone { get; set; }
        public Posicao Posicao { get; set; }
    }
}