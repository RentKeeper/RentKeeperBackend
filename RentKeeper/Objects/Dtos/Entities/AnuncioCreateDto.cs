using System;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class AnuncioCreateDto
    {
        public string AnuncioJogador { get; set; } = string.Empty;
        public string AnuncioPartida { get; set; } = string.Empty;
        public string LocalPartida { get; set; } = string.Empty;
        public DateTime DataPartida { get; set; }
        public DateTime HoraPartida { get; set; }
        public int UsuarioId { get; set; }
    }
}
