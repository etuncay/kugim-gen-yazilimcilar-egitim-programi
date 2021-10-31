using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class BasvuruEntityEmailtoEposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Basvuru",
                newName: "Eposta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Eposta",
                table: "Basvuru",
                newName: "Email");
        }
    }
}
