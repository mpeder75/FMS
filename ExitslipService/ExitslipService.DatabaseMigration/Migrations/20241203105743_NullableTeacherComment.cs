using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExitslipService.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class NullableTeacherComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherComment",
                table: "ExitSlipPosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherComment",
                table: "ExitSlipPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
