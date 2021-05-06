using Microsoft.EntityFrameworkCore.Migrations;

namespace ViceIO.Data.Migrations
{
    public partial class DeleteLocalUrlPropertyFromPictureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalUrl",
                table: "Pictures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalUrl",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
