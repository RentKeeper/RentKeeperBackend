using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class UsuarioReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Posicao Posicao { get; set; }
        public int? TimeId { get; set; }
    }
}