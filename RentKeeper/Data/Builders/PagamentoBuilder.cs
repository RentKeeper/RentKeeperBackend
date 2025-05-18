using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Builders
{
    public class PagamentoBuilder : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos");
            builder.HasKey(p => p.IdPagamento);

            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.FormaPagamento).IsRequired();
            builder.Property(p => p.PorcentagemRecebida).IsRequired();

            builder.HasOne(p => p.Aluguel)
                   .WithOne(a => a.Pagamento)
                   .HasForeignKey<Pagamento>(p => p.AluguelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
