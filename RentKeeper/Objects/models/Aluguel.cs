using System.ComponentModel.DataAnnotations.Schema;
[Table("Aluguel")]
public class Aluguel
{
    [Column("IdAluguel")]
    public int IdAluguel { get; set; }
    [Column("ValorAluguel")]
    public decimal ValorAluguel { get; set; } 
    [Column("AvaliacaoJogador")]
    public int AvaliacaoJogador { get; set; } 

  
    public Aluguel()
    {
    }

    public Aluguel(int idAluguel, decimal valorAluguel, int avaliacaoJogador)
    {
        IdAluguel = idAluguel;
        ValorAluguel = valorAluguel;
        AvaliacaoJogador = avaliacaoJogador;
    }
}
