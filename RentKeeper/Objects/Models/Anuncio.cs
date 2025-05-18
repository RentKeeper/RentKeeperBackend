using System;
using System.Collections.Generic;
using RentKeeper.Objects.Models; // para relacionamentos, se necessário

namespace RentKeeper.Objects.Models
{
    public class Anuncio
    {
        public int IdAnuncio { get; set; }
        public string AnuncioJogador { get; set; }
        public string AnuncioPartida { get; set; }
        public string LocalPartida { get; set; }
        public DateTime DataPartida { get; set; }
        public DateTime HoraPartida { get; set; }
        public bool Disponivel { get; set; } = true;

        // FK para Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Navegações
        public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
        public Pagamento? Pagamento { get; set; }
    }
}