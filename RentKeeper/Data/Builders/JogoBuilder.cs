using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Builders
{
    public class JogoBuilder : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("Jogos");
            builder.HasKey(j => j.IdJogo);

            builder.Property(j => j.DataHora)
                   .IsRequired();

            builder.Property(j => j.Local)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(j => j.Status)
                   .IsRequired()
                   .HasMaxLength(40);

            builder.Property(j => j.Observacoes)
                   .HasMaxLength(500);

            builder.HasOne(j => j.TimeMandante)
                   .WithMany(t => t.JogosComoMandante)
                   .HasForeignKey(j => j.TimeMandanteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(j => j.TimeVisitante)
                   .WithMany(t => t.JogosComoVisitante)
                   .HasForeignKey(j => j.TimeVisitanteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
