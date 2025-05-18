using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentKeeper.Objects.Models;


namespace RentKeeper.Data.Builders
{
    public class UsuarioBuilder : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Senha)
                .IsRequired();

            builder.Property(u => u.Cpf)
                .IsRequired();

            builder.Property(u => u.Telefone)
                .IsRequired();

            builder.Property(u => u.Posicao)
                .IsRequired();

            // Relacionamento com Time (opcional)
            builder.HasOne(u => u.Time)
                   .WithMany(t => t.Usuarios)
                   .HasForeignKey(u => u.TimeId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Navegações
            builder.HasMany(u => u.AnunciosCriados)
                   .WithOne(a => a.Usuario)
                   .HasForeignKey(a => a.UsuarioId);

            builder.HasMany(u => u.AlugueisFeitos)
                    .WithOne(al => al.Contratante)      
                    .HasForeignKey(al => al.ContratanteId);
        }
    }
}