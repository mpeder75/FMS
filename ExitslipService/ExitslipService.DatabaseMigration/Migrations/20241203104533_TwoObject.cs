using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExitslipService.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class TwoObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExitSlipPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDistributed = table.Column<bool>(type: "bit", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitSlipPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExitSlipReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitSlipReplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExitSlipPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExitSlipReplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionForm_ExitSlipPosts_ExitSlipPostId",
                        column: x => x.ExitSlipPostId,
                        principalTable: "ExitSlipPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionForm_ExitSlipReplies_ExitSlipReplyId",
                        column: x => x.ExitSlipReplyId,
                        principalTable: "ExitSlipReplies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionForm_ExitSlipPostId",
                table: "QuestionForm",
                column: "ExitSlipPostId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionForm_ExitSlipReplyId",
                table: "QuestionForm",
                column: "ExitSlipReplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionForm");

            migrationBuilder.DropTable(
                name: "ExitSlipPosts");

            migrationBuilder.DropTable(
                name: "ExitSlipReplies");
        }
    }
}
