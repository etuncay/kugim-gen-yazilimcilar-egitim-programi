using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class AnaDersEntityForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AnaDers_UstId",
                table: "AnaDers",
                column: "UstId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnaDers_AnaDers_UstId",
                table: "AnaDers",
                column: "UstId",
                principalTable: "AnaDers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnaDers_AnaDers_UstId",
                table: "AnaDers");

            migrationBuilder.DropIndex(
                name: "IX_AnaDers_UstId",
                table: "AnaDers");
        }
    }
}
