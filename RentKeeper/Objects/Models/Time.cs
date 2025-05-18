using System.Collections.Generic;

namespace RentKeeper.Objects.Models
{
    public class Time
    {
        public int IdTime { get; set; }
        public string NomeTime { get; set; } = string.Empty;
        public int QuantidadeJogadores { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
