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

            builder.Property(a => a.Titulo)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Descricao)
                   .HasMaxLength(500);

            builder.Property(a => a.LocalPartida)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(a => a.DataHoraPartida)
                   .IsRequired();

            builder.Property(a => a.Experiencia)
                   .HasMaxLength(50);

            builder.Property(a => a.Posicao)
                   .IsRequired();

            builder.Property(a => a.Preco)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(a => a.TipoPartida)
                   .HasMaxLength(50);

            builder.Property(a => a.Disponivel)
                   .IsRequired();

            // Conversão para armazenar a lista de disponibilidade como string
            builder.Property(a => a.Disponibilidade)
                   .HasConversion(
                       v => string.Join(";", v),
                       v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                   )
                   .HasMaxLength(300);

            // Relacionamento com Usuario
            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.AnunciosCriados)
                   .HasForeignKey(a => a.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento com Alugueis (1:N)
            builder.HasMany(a => a.Alugueis)
                   .WithOne(al => al.Anuncio)
                   .HasForeignKey(al => al.AnuncioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}