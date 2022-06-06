﻿// <auto-generated />
using System;
using LPsalut.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LPsalut.Infrastructure.Data.Migrations
{
    [DbContext(typeof(LPsalutDbContext))]
    [Migration("20220603014611_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LPsalut.Domain.NotaFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("canal_compra")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CANAL_COMPRA");

                    b.Property<int>("cnpj")
                        .HasColumnType("int")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("data_compra")
                        .HasColumnType("date")
                        .HasColumnName("DATA_COMPRA");

                    b.Property<string>("img_nf")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("IMG_NF");

                    b.Property<int>("n_cupom")
                        .HasColumnType("int")
                        .HasColumnName("N_CUPOM");

                    b.Property<decimal>("valor_total")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("VALOR_TOTAL");

                    b.HasKey("Id");

                    b.ToTable("NotaFiscals");
                });

            modelBuilder.Entity("LPsalut.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NotaFiscalId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("NOME");

                    b.Property<decimal>("preco")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("PRECO");

                    b.HasKey("Id");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LPsalut.Domain.Produto", b =>
                {
                    b.HasOne("LPsalut.Domain.NotaFiscal", null)
                        .WithMany("Produtos")
                        .HasForeignKey("NotaFiscalId");
                });

            modelBuilder.Entity("LPsalut.Domain.NotaFiscal", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
