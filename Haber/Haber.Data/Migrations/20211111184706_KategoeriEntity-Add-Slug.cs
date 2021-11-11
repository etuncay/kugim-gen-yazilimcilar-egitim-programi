using Microsoft.EntityFrameworkCore.Migrations;

namespace Haber.Data.Migrations
{
    public partial class KategoeriEntityAddSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Kategori",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Kategori");
        }
    }
}
