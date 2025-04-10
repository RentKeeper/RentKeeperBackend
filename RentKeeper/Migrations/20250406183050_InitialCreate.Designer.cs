﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentKeeper.Data.Context;

#nullable disable

namespace RentKeeper.Migrations
{
    [DbContext(typeof(RentKeeperDbContext))]
    [Migration("20250406183050_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RentKeeper.Models.Aluguel", b =>
                {
                    b.Property<int>("IdAluguel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdAluguel"));

                    b.Property<int>("AvaliacaoJogador")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorAluguel")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdAluguel");

                    b.ToTable("Aluguel");
                });

            modelBuilder.Entity("RentKeeper.Models.Goleiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PrecoPorJogo")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Goleiros");
                });
#pragma warning restore 612, 618
        }
    }
}
