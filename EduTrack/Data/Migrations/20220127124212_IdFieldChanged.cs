using Microsoft.EntityFrameworkCore.Migrations;

namespace EduTrack.Data.Migrations
{
    public partial class IdFieldChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_TeacherID",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_TeacherID",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_AspNetUsers_StudentID",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_TeacherID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Assignment");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "StudentEnrollment",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollment_StudentID",
                table: "StudentEnrollment",
                newName: "IX_StudentEnrollment_Id");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherID",
                table: "Courses",
                newName: "IX_Courses_Id");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Announcement",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_TeacherID",
                table: "Announcement",
                newName: "IX_Announcement_Id");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Assignment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_Id",
                table: "Assignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_Id",
                table: "Courses",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_AspNetUsers_Id",
                table: "StudentEnrollment",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_Id",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_AspNetUsers_Id",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_Id",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Assignment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentEnrollment",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollment_Id",
                table: "StudentEnrollment",
                newName: "IX_StudentEnrollment_StudentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Id",
                table: "Courses",
                newName: "IX_Courses_TeacherID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Announcement",
                newName: "TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_Id",
                table: "Announcement",
                newName: "IX_Announcement_TeacherID");

            migrationBuilder.AddColumn<string>(
                name: "TeacherID",
                table: "Assignment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TeacherID",
                table: "Assignment",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_TeacherID",
                table: "Announcement",
                column: "TeacherID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_TeacherID",
                table: "Assignment",
                column: "TeacherID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherID",
                table: "Courses",
                column: "TeacherID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_AspNetUsers_StudentID",
                table: "StudentEnrollment",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
