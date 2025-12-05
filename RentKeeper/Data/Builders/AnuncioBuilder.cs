using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                     var disponibilidadeComparer = new ValueComparer<List<string>>(
                            (left, right) =>
                                   (left ?? new List<string>()).SequenceEqual(right ?? new List<string>()),
                            value =>
                                   (value ?? new List<string>()).Aggregate(0, (current, item) =>
                                          HashCode.Combine(current, item != null ? item.GetHashCode() : 0)),
                            value => (value ?? new List<string>()).ToList());

                     var disponibilidadeProperty = builder.Property(a => a.Disponibilidade)
                            .HasConversion(
                                   v => string.Join(";", v ?? new List<string>()),
                                   v => (v ?? string.Empty)
                                          .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                          .ToList());

                     disponibilidadeProperty.Metadata.SetValueComparer(disponibilidadeComparer);
                     disponibilidadeProperty.HasMaxLength(300);

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