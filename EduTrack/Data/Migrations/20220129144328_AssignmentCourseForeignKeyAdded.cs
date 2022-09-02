using Microsoft.EntityFrameworkCore.Migrations;

namespace EduTrack.Data.Migrations
{
    public partial class AssignmentCourseForeignKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Assignment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Assignment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_Id",
                table: "Assignment",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
