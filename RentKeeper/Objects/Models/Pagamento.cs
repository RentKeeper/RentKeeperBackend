using RentKeeper.Objects.Enums;

namespace RentKeeper.Objects.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public float Valor { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public float PorcentagemRecebida { get; set; }

        // FK para Aluguel
        public int AluguelId { get; set; }
        public Aluguel Aluguel { get; set; } = null!;
    }
}
