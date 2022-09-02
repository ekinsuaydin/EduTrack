using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduTrack.Data.Migrations
{
    public partial class AssignmentTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement");

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Assignment",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Announcement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Announcement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_Id",
                table: "Announcement",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
