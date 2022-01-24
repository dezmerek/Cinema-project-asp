using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProjectASP.Migrations
{
    public partial class FixOdKiedy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OdKiey",
                table: "Films",
                newName: "OdKiedy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OdKiedy",
                table: "Films",
                newName: "OdKiey");
        }
    }
}
