using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Builders
{
    public class AnuncioBuilder : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.ToTable("Anuncios");
            builder.HasKey(a => a.IdAnuncio);

            builder.Property(a => a.AnuncioJogador)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.AnuncioPartida)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.LocalPartida)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(a => a.DataPartida)
                   .IsRequired();

            builder.Property(a => a.HoraPartida)
                   .IsRequired();

            builder.Property(a => a.Disponivel)
                   .IsRequired();

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.AnunciosCriados)
                   .HasForeignKey(a => a.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
