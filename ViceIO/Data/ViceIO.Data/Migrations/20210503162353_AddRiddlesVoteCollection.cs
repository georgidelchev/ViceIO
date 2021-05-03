using Microsoft.EntityFrameworkCore.Migrations;

namespace ViceIO.Data.Migrations
{
    public partial class AddRiddlesVoteCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiddleId",
                table: "RiddleVotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiddleVotes_RiddleId",
                table: "RiddleVotes",
                column: "RiddleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RiddleVotes_Riddles_RiddleId",
                table: "RiddleVotes",
                column: "RiddleId",
                principalTable: "Riddles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiddleVotes_Riddles_RiddleId",
                table: "RiddleVotes");

            migrationBuilder.DropIndex(
                name: "IX_RiddleVotes_RiddleId",
                table: "RiddleVotes");

            migrationBuilder.DropColumn(
                name: "RiddleId",
                table: "RiddleVotes");
        }
    }
}
