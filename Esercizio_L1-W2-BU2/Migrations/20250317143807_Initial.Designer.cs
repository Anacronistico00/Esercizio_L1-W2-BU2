﻿// <auto-generated />
using System;
using Esercizio_L1_W2_BU2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Esercizio_L1_W2_BU2.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250317143807_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Esercizio_L1_W2_BU2.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataDiNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f8b2a0c-5d3b-4f71-a6a7-2c5f91e3d8b1"),
                            Cognome = "Turiaci",
                            DataDiNascita = new DateTime(2000, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vittorioturiaci@email.com",
                            Nome = "Vittorio"
                        },
                        new
                        {
                            Id = new Guid("b7a4cfe9-83b6-4b4e-9e1d-7c8f5b2a6d3c"),
                            Cognome = "Barberis",
                            DataDiNascita = new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "rachelebarberis@email.com",
                            Nome = "Rachele"
                        },
                        new
                        {
                            Id = new Guid("e2f1d4a7-9b8c-456e-a2f3-7d1c4e8b9a6f"),
                            Cognome = "Santella",
                            DataDiNascita = new DateTime(2000, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alessandrosantella@email.com",
                            Nome = "Alessandro"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
