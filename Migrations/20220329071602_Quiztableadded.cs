using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz_api.Migrations
{
    public partial class Quiztableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsSubmitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    TotalQuestions = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCorrectAnswer = table.Column<int>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attempts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<long>(type: "INTEGER", nullable: false),
                    ContiansImage = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AttemptLines",
                columns: table => new
                {
                    AttemptID = table.Column<long>(type: "INTEGER", nullable: false),
                    QuizID = table.Column<long>(type: "INTEGER", nullable: false),
                    IsAnswered = table.Column<bool>(type: "INTEGER", nullable: false),
                    SelectedOption = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttemptLines", x => new { x.AttemptID, x.QuizID });
                    table.ForeignKey(
                        name: "FK_AttemptLines_Attempts_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Attempts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttemptLines_Quizzes_AttemptID",
                        column: x => x.AttemptID,
                        principalTable: "Quizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ContiansImage = table.Column<bool>(type: "INTEGER", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    QuizID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Options_Quizzes_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizImages",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    QuizID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuizImages_Quizzes_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionImages",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    OptionID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OptionImages_Options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttemptLines_QuizID",
                table: "AttemptLines",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_AppUserId",
                table: "Attempts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionImages_OptionID",
                table: "OptionImages",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuizID",
                table: "Options",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizImages_QuizID",
                table: "QuizImages",
                column: "QuizID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttemptLines");

            migrationBuilder.DropTable(
                name: "OptionImages");

            migrationBuilder.DropTable(
                name: "QuizImages");

            migrationBuilder.DropTable(
                name: "Attempts");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
