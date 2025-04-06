namespace RentKeeper.Objects.Dtos.Entities
{
    public class GoleiroDto
    {
        public string Nome { get; set; }
        public decimal PrecoPorJogo { get; set; }
        public bool Disponivel { get; set; }
        public int Avaliacao { get; set; }
        public int UsuarioId { get; set; }
    }
}
