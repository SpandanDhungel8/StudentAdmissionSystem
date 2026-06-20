using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdmissionSystem.Migrations
{
    /// <inheritdoc />
    public partial class _2ndOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Courses_CourseId1",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_CourseId1",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Admissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Admissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_CourseId1",
                table: "Admissions",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Courses_CourseId1",
                table: "Admissions",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }
    }
}
