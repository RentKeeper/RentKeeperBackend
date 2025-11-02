using System.Collections.Generic;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class TimeDto
    {
        public int IdTime { get; set; }
        public string NomeTime { get; set; }
        public int QuantidadeJogadores { get; set; }
        public ICollection<int> UsuarioIds { get; set; } = new List<int>();
    }
}
