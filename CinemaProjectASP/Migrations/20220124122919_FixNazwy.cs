using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProjectASP.Migrations
{
    public partial class FixNazwy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktors_Films_Aktors_AktorId",
                table: "Aktors_Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Aktors_Films_Films_FilmId",
                table: "Aktors_Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Rezysers_RezyserId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Salas_SalaId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salas",
                table: "Salas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezysers",
                table: "Rezysers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Films",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aktors_Films",
                table: "Aktors_Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aktors",
                table: "Aktors");

            migrationBuilder.RenameTable(
                name: "Salas",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "Rezysers",
                newName: "Rezyserzy");

            migrationBuilder.RenameTable(
                name: "Films",
                newName: "Filmy");

            migrationBuilder.RenameTable(
                name: "Aktors_Films",
                newName: "Aktorzy_Filmy");

            migrationBuilder.RenameTable(
                name: "Aktors",
                newName: "Aktorzy");

            migrationBuilder.RenameIndex(
                name: "IX_Films_SalaId",
                table: "Filmy",
                newName: "IX_Filmy_SalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Films_RezyserId",
                table: "Filmy",
                newName: "IX_Filmy_RezyserId");

            migrationBuilder.RenameIndex(
                name: "IX_Aktors_Films_FilmId",
                table: "Aktorzy_Filmy",
                newName: "IX_Aktorzy_Filmy_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezyserzy",
                table: "Rezyserzy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmy",
                table: "Filmy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aktorzy_Filmy",
                table: "Aktorzy_Filmy",
                columns: new[] { "AktorId", "FilmId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aktorzy",
                table: "Aktorzy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktorzy_Filmy_Aktorzy_AktorId",
                table: "Aktorzy_Filmy",
                column: "AktorId",
                principalTable: "Aktorzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aktorzy_Filmy_Filmy_FilmId",
                table: "Aktorzy_Filmy",
                column: "FilmId",
                principalTable: "Filmy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmy_Rezyserzy_RezyserId",
                table: "Filmy",
                column: "RezyserId",
                principalTable: "Rezyserzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmy_Sale_SalaId",
                table: "Filmy",
                column: "SalaId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktorzy_Filmy_Aktorzy_AktorId",
                table: "Aktorzy_Filmy");

            migrationBuilder.DropForeignKey(
                name: "FK_Aktorzy_Filmy_Filmy_FilmId",
                table: "Aktorzy_Filmy");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmy_Rezyserzy_RezyserId",
                table: "Filmy");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmy_Sale_SalaId",
                table: "Filmy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezyserzy",
                table: "Rezyserzy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmy",
                table: "Filmy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aktorzy_Filmy",
                table: "Aktorzy_Filmy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aktorzy",
                table: "Aktorzy");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Salas");

            migrationBuilder.RenameTable(
                name: "Rezyserzy",
                newName: "Rezysers");

            migrationBuilder.RenameTable(
                name: "Filmy",
                newName: "Films");

            migrationBuilder.RenameTable(
                name: "Aktorzy_Filmy",
                newName: "Aktors_Films");

            migrationBuilder.RenameTable(
                name: "Aktorzy",
                newName: "Aktors");

            migrationBuilder.RenameIndex(
                name: "IX_Filmy_SalaId",
                table: "Films",
                newName: "IX_Films_SalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Filmy_RezyserId",
                table: "Films",
                newName: "IX_Films_RezyserId");

            migrationBuilder.RenameIndex(
                name: "IX_Aktorzy_Filmy_FilmId",
                table: "Aktors_Films",
                newName: "IX_Aktors_Films_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salas",
                table: "Salas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezysers",
                table: "Rezysers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Films",
                table: "Films",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aktors_Films",
                table: "Aktors_Films",
                columns: new[] { "AktorId", "FilmId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aktors",
                table: "Aktors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktors_Films_Aktors_AktorId",
                table: "Aktors_Films",
                column: "AktorId",
                principalTable: "Aktors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aktors_Films_Films_FilmId",
                table: "Aktors_Films",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Rezysers_RezyserId",
                table: "Films",
                column: "RezyserId",
                principalTable: "Rezysers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Salas_SalaId",
                table: "Films",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
