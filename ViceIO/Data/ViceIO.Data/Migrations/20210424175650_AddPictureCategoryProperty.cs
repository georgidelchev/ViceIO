using Microsoft.EntityFrameworkCore.Migrations;

namespace ViceIO.Data.Migrations
{
    public partial class AddPictureCategoryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CategoryId",
                table: "Pictures",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Categories_CategoryId",
                table: "Pictures",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Categories_CategoryId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_CategoryId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Pictures");
        }
    }
}
