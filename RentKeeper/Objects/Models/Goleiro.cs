using System.ComponentModel.DataAnnotations.Schema;

namespace RentKeeper.Models
{
    public class Goleiro
    {
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; } 
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal PrecoPorJogo { get; set; }
        public bool Disponivel { get; set; } = true;
        public int Avaliacao { get; set; } 
    }
}
