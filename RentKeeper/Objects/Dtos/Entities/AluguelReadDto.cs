﻿namespace RentKeeper.Objects.Dtos.Entities
{
    public class AluguelReadDto
    {
        public int IdAluguel { get; set; }
        public float ValorAluguel { get; set; }
        public int? AvaliacaoJogador { get; set; }
        public int AnuncioId { get; set; }
        public int ContratanteId { get; set; }
    }
}
