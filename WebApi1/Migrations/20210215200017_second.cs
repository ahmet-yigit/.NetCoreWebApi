using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SepetUruns",
                newName: "SepetUrunId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sepets",
                newName: "SepetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Musteris",
                newName: "MusteriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SepetUrunId",
                table: "SepetUruns",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SepetId",
                table: "Sepets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MusteriId",
                table: "Musteris",
                newName: "Id");
        }
    }
}
