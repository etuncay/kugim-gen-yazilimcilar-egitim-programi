using Microsoft.EntityFrameworkCore.Migrations;

namespace Haber.Data.Migrations
{
    public partial class YorumEntityAddKullaniciId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Yorum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KullaniciId",
                table: "Yorum",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Kullanici_KullaniciId",
                table: "Yorum",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Kullanici_KullaniciId",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_KullaniciId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Yorum");
        }
    }
}
