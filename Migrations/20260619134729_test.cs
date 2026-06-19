using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdmissionSystem.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions");

            migrationBuilder.AlterColumn<int>(
                name: "StuId",
                table: "Admissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Admissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions",
                column: "StuId",
                principalTable: "Students",
                principalColumn: "StuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions");

            migrationBuilder.AlterColumn<int>(
                name: "StuId",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Courses_CourseId",
                table: "Admissions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions",
                column: "StuId",
                principalTable: "Students",
                principalColumn: "StuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
