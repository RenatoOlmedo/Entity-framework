using LPsalut.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPsalut.Infrastructure.Data.DataMappings
{
    internal class NotaFiscalMapping : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Produtos)
                .HasColumnName("PRODUTOS")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.Valor_total)
                .HasColumnName("VALOR_TOTAL")
                .HasColumnType("decimal")
                .HasPrecision(4, 2)
                .IsRequired();

            builder.Property(p => p.Cnpj)
                .HasColumnName("CNPJ")
                .HasColumnType("varchar")
                .HasMaxLength(30000000)
                .IsRequired();

            builder.Property(p => p.N_cupom)
                .HasColumnName("N_CUPOM")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Canal_compra)
                .HasColumnName("CANAL_COMPRA")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Data_compra)
                .HasColumnName("DATA_COMPRA")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Img_nf)
                .HasColumnName("IMG_NF")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
