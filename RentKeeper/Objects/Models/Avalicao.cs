using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

[Table("Avalicao")] 
public class Avaliacao
{
    [Column("IdAvalicao")]
    public int IdAvalicao { get; set; }
    [Column("DataAvalicao")]
    public DateTime DataAvalicao { get; set; }
    [Column("NotaAvalicao")]
    public int NotaAvalicao { get; set; }
    [Column("ComentarioAvalicao")]
    public string ComentarioAvalicao { get; set; }

    // Construtor
    public Avaliacao()
    {
    }
    public Avaliacao(int idAvalicao, DateTime dataAvalicao, int notaAvalicao, string comentarioAvalicao)
    {
        IdAvalicao = idAvalicao;
        DataAvalicao = dataAvalicao;
        NotaAvalicao = notaAvalicao;
        ComentarioAvalicao = comentarioAvalicao;
    }
}
