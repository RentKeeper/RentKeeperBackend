using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentKeeper.Models
{
    [Table("Aluguel")]
    public class Aluguel
    {
        [Key]
        public int IdAluguel { get; set; }

        public decimal ValorAluguel { get; set; }

        public int AvaliacaoJogador { get; set; }
    }
}
