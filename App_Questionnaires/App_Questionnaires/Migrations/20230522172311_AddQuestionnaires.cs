using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Questionnaires.Migrations
{
    public partial class AddQuestionnaires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionnaireId",
                table: "Question",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Questionnaire_QuestionnaireId",
                table: "Question",
                column: "QuestionnaireId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Questionnaire_QuestionnaireId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Questionnaire");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuestionnaireId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Question");
        }
    }
}
