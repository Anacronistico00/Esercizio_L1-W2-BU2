using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esercizio_L1_W2_BU2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataDiNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cognome", "DataDiNascita", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("1f8b2a0c-5d3b-4f71-a6a7-2c5f91e3d8b1"), "Turiaci", new DateTime(2000, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "vittorioturiaci@email.com", "Vittorio" },
                    { new Guid("b7a4cfe9-83b6-4b4e-9e1d-7c8f5b2a6d3c"), "Barberis", new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "rachelebarberis@email.com", "Rachele" },
                    { new Guid("e2f1d4a7-9b8c-456e-a2f3-7d1c4e8b9a6f"), "Santella", new DateTime(2000, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alessandrosantella@email.com", "Alessandro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
