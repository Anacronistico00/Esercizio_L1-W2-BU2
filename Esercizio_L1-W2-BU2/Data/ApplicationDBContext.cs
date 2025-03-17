using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Esercizio_L1_W2_BU2.Models;

namespace Esercizio_L1_W2_BU2.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = new Guid("1f8b2a0c-5d3b-4f71-a6a7-2c5f91e3d8b1"),
                    Nome = "Vittorio",
                    Cognome = "Turiaci",
                    DataDiNascita = new DateTime(2000, 7, 9),
                    Email = "vittorioturiaci@email.com"
                },
                new Student
                {
                    Id = new Guid("b7a4cfe9-83b6-4b4e-9e1d-7c8f5b2a6d3c"),
                    Nome = "Rachele",
                    Cognome = "Barberis",
                    DataDiNascita = new DateTime(2001, 2, 3),
                    Email = "rachelebarberis@email.com"
                },
                new Student
                {
                    Id = new Guid("e2f1d4a7-9b8c-456e-a2f3-7d1c4e8b9a6f"),
                    Nome = "Alessandro",
                    Cognome = "Santella",
                    DataDiNascita = new DateTime(2000, 5, 21),
                    Email = "alessandrosantella@email.com"
                }
            );
        }
    }
}
