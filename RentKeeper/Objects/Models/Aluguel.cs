namespace RentKeeper.Objects.Models
{
    public class Aluguel
    {
        public int IdAluguel { get; set; }
        public float ValorAluguel { get; set; }
        public int? AvaliacaoJogador { get; set; }

        // FK para Anuncio
        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; } = null!;

        // FK para Usuario (contratante)
        public int ContratanteId { get; set; }
        public Usuario Contratante { get; set; } = null!;
        public Pagamento? Pagamento { get; set; }
    }
}
