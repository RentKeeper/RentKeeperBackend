using System.Collections.Generic;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class TimeReadDto
    {
        public int IdTime { get; set; }
        public string NomeTime { get; set; }
        public int QuantidadeJogadores { get; set; }
        public ICollection<int> UsuarioIds { get; set; } = new List<int>();
    }
}
