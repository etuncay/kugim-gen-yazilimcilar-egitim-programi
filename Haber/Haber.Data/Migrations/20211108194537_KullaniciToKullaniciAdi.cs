using Microsoft.EntityFrameworkCore.Migrations;

namespace Haber.Data.Migrations
{
    public partial class KullaniciToKullaniciAdi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kullanici",
                table: "Kullanici",
                newName: "KullaniciAdi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KullaniciAdi",
                table: "Kullanici",
                newName: "Kullanici");
        }
    }
}
