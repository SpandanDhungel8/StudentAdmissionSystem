using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdmissionSystem.Migrations
{
    /// <inheritdoc />
    public partial class AdmissionWithCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions");

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
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Courses_CourseId1",
                table: "Admissions",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Courses_CourseId1",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_CourseId1",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Admissions");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }
    }
}
