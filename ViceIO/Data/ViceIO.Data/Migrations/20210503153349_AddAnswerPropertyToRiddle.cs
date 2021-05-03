using Microsoft.EntityFrameworkCore.Migrations;

namespace ViceIO.Data.Migrations
{
    public partial class AddAnswerPropertyToRiddle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Riddles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Riddles");
        }
    }
}
