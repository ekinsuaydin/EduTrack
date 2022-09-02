using Microsoft.EntityFrameworkCore.Migrations;

namespace EduTrack.Data.Migrations
{
    public partial class UpdateDBAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Courses_CourseID",
                table: "Assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "Assignments");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_Id",
                table: "Assignments",
                newName: "IX_Assignments_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_CourseID",
                table: "Assignments",
                newName: "IX_Assignments_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_Id",
                table: "Assignments",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseID",
                table: "Assignments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_Id",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseID",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_Id",
                table: "Assignment",
                newName: "IX_Assignment_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignment",
                newName: "IX_Assignment_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Courses_CourseID",
                table: "Assignment",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
