using System;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class AnuncioReadDto
    {
        public int IdAnuncio { get; set; }
        public string AnuncioJogador { get; set; }
        public string AnuncioPartida { get; set; }
        public string LocalPartida { get; set; }
        public DateTime DataPartida { get; set; }
        public DateTime HoraPartida { get; set; }
        public bool Disponivel { get; set; }
        public int UsuarioId { get; set; }
    }
}
