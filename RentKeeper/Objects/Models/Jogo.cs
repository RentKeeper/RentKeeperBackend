using System;

namespace RentKeeper.Objects.Models
{
    public class Jogo
    {
        public int IdJogo { get; set; }
        public int TimeMandanteId { get; set; }
        public Time TimeMandante { get; set; } = null!;
        public int TimeVisitanteId { get; set; }
        public Time TimeVisitante { get; set; } = null!;
        public DateTime DataHora { get; set; }
        public string Local { get; set; } = string.Empty;
        public string? Observacoes { get; set; }
        public string Status { get; set; } = "Agendado";
    }
}
