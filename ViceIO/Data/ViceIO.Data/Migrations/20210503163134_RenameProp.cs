using Microsoft.EntityFrameworkCore.Migrations;

namespace ViceIO.Data.Migrations
{
    public partial class RenameProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Pictures",
                newName: "LocalUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalUrl",
                table: "Pictures",
                newName: "Url");
        }
    }
}
