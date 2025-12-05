using System;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class JogoDto
    {
        public int IdJogo { get; set; }
        public int TimeMandanteId { get; set; }
        public int TimeVisitanteId { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; } = string.Empty;
        public string? Observacoes { get; set; }
        public string Status { get; set; } = "Agendado";
        public string? TimeMandanteNome { get; set; }
        public string? TimeVisitanteNome { get; set; }
    }
}
