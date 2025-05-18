﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Builders
{
    public class TimeBuilder : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.ToTable("Times");
            builder.HasKey(t => t.IdTime);

            builder.Property(t => t.NomeTime)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.QuantidadeJogadores)
                   .IsRequired();

            builder.HasMany(t => t.Usuarios)
                   .WithOne(u => u.Time)
                   .HasForeignKey(u => u.TimeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
