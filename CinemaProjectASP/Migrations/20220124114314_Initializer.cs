using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProjectASP.Migrations
{
    public partial class Initializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RokUrodzenia = table.Column<int>(type: "int", nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezysers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RokUrodzenia = table.Column<int>(type: "int", nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezysers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    OdKiey = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoKiedy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmKategoria = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    RezyserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Rezysers_RezyserId",
                        column: x => x.RezyserId,
                        principalTable: "Rezysers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aktors_Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    AktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktors_Films", x => new { x.AktorId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_Aktors_Films_Aktors_AktorId",
                        column: x => x.AktorId,
                        principalTable: "Aktors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aktors_Films_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktors_Films_FilmId",
                table: "Aktors_Films",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_RezyserId",
                table: "Films",
                column: "RezyserId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_SalaId",
                table: "Films",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktors_Films");

            migrationBuilder.DropTable(
                name: "Aktors");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Rezysers");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
