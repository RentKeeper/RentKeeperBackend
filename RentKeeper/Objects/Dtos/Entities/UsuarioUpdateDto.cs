using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class UsuarioUpdateDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? ChavePix { get; set; }
        public Posicao? Posicao { get; set; }
    }
}
