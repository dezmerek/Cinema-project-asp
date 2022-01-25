using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProjectASP.Migrations
{
    public partial class userFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImieNazwisko",
                table: "AspNetUsers",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "ImieNazwisko");
        }
    }
}
