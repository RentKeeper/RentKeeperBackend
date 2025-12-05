using System;
using System.Collections.Generic;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class AnuncioDto
    {
        public int IdAnuncio { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string LocalPartida { get; set; }
        public DateTime DataHoraPartida { get; set; }
        public List<string> Disponibilidade { get; set; } = new();
        public string Experiencia { get; set; }
        public int Posicao { get; set; }
        public decimal Preco { get; set; }
        public string TipoPartida { get; set; }
        public bool Disponivel { get; set; } = true;
        public int UsuarioId { get; set; }
        public double? MediaAvaliacao { get; set; }
        public int TotalAvaliacoes { get; set; }
    }
}
