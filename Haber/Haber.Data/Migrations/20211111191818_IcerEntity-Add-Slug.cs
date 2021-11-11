using Microsoft.EntityFrameworkCore.Migrations;

namespace Haber.Data.Migrations
{
    public partial class IcerEntityAddSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Icerik",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Icerik");
        }
    }
}
