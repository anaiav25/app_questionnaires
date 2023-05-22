using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Questionnaires.Migrations
{
    public partial class UpdateQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ParentId",
                table: "Question",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Question_ParentId",
                table: "Question",
                column: "ParentId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Question_ParentId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ParentId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
