using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpletnoNarociloBaza.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Narocniki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narocniki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Narocila",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NarocnikId = table.Column<int>(type: "INTEGER", nullable: false),
                    DatumNarocila = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CenaNarocila = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narocila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narocila_Narocniki_NarocnikId",
                        column: x => x.NarocnikId,
                        principalTable: "Narocniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narocila_NarocnikId",
                table: "Narocila",
                column: "NarocnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narocila");

            migrationBuilder.DropTable(
                name: "Narocniki");
        }
    }
}
