using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

[Table("Anuncio")]
public class Anuncio
{
    [Column("IdAnuncio")]
    public int IdAnuncio { get; set; }
    [Column("AnuncioJogador")]
    public string AnuncioJogador { get; set; }
    [Column("AnuncioPartida")]
    public string AnuncioPartida { get; set; }

    public Anuncio()
    {
    }
    public Anuncio(int idAnuncio, string anuncioJogador, string anuncioPartida)
    {
        IdAnuncio = idAnuncio;
        AnuncioJogador = anuncioJogador;
        AnuncioPartida = anuncioPartida;
      
    }
}