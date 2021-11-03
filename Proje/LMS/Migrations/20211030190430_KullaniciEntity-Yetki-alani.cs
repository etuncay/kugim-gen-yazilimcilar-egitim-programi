using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class KullaniciEntityYetkialani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Yetki",
                table: "Kullanici",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yetki",
                table: "Kullanici");
        }
    }
}
