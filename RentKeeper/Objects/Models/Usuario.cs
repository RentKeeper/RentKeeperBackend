using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int Cpf { get; set; }

        public int Telefone { get; set; }

        public Posicao Posicao { get; set; }

        // Relacionamento opcional com Time
        public int? TimeId { get; set; }
        public Time? Time { get; set; }

        // Relacionamentos com Anuncios e Alugueis
        public ICollection<Anuncio> AnunciosCriados { get; set; } = new List<Anuncio>();
        public ICollection<Aluguel> AlugueisFeitos { get; set; } = new List<Aluguel>();
    }
}
