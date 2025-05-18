using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Dtos.Entities
{
    public class PagamentoCreateDto
    {
        public float Valor { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public float PorcentagemRecebida { get; set; }
        public int AluguelId { get; set; }
    }
}
