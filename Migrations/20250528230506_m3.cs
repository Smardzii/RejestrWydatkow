using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RejestrWydatkow.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Wydatek",
                columns: new[] { "Id", "Data", "Kategoria", "Kwota", "Opis" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jedzenie", 150.75, "Zakupy spożywcze" },
                    { 2, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transport", 220.0, "Paliwo" },
                    { 3, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rozrywka", 45.0, "Kino" },
                    { 4, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subskrypcje", 55.0, "Abonament Netflix" },
                    { 5, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media", 300.0, "Rachunek za prąd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wydatek",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wydatek",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wydatek",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wydatek",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wydatek",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
