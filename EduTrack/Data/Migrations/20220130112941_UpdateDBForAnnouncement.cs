using Microsoft.EntityFrameworkCore.Migrations;

namespace EduTrack.Data.Migrations
{
    public partial class UpdateDBForAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_Courses_CourseID",
                table: "Announcement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcement",
                table: "Announcement");

            migrationBuilder.RenameTable(
                name: "Announcement",
                newName: "Announcements");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_Id",
                table: "Announcements",
                newName: "IX_Announcements_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_CourseID",
                table: "Announcements",
                newName: "IX_Announcements_CourseID");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements",
                column: "AnnouncementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_Id",
                table: "Announcements",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Courses_CourseID",
                table: "Announcements",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_Id",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Courses_CourseID",
                table: "Announcements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements");

            migrationBuilder.RenameTable(
                name: "Announcements",
                newName: "Announcement");

            migrationBuilder.RenameIndex(
                name: "IX_Announcements_Id",
                table: "Announcement",
                newName: "IX_Announcement_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Announcements_CourseID",
                table: "Announcement",
                newName: "IX_Announcement_CourseID");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Announcement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcement",
                table: "Announcement",
                column: "AnnouncementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_Courses_CourseID",
                table: "Announcement",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
