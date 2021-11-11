using Microsoft.EntityFrameworkCore.Migrations;

namespace Haber.Data.Migrations
{
    public partial class ResimEntityAddAciklama2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Resim",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Resim");
        }
    }
}
