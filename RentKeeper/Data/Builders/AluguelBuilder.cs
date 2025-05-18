using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Builders
{
    public class AluguelBuilder : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("Alugueis");
            builder.HasKey(a => a.IdAluguel);

            builder.Property(a => a.ValorAluguel)
                   .IsRequired();

            builder.Property(a => a.AvaliacaoJogador)
                   .IsRequired(false);

            // Relação com Anuncio
            builder.HasOne(a => a.Anuncio)
                   .WithMany(an => an.Alugueis)
                   .HasForeignKey(a => a.AnuncioId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relação com Usuario (contratante)
            builder.HasOne(a => a.Contratante)
                   .WithMany(u => u.AlugueisFeitos)
                   .HasForeignKey(a => a.ContratanteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
