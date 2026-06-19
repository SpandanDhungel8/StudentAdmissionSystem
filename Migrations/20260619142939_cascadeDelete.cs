using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdmissionSystem.Migrations
{
    /// <inheritdoc />
    public partial class cascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions",
                column: "StuId",
                principalTable: "Students",
                principalColumn: "StuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Students_StuId",
                table: "Admissions",
                column: "StuId",
                principalTable: "Students",
                principalColumn: "StuId");
        }
    }
}
