using Microsoft.EntityFrameworkCore.Migrations;

namespace EduTrack.Data.Migrations
{
    public partial class SubmissionTableUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Assignments_AssignmentID",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "AssignmentID",
                table: "Submissions",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_AssignmentID",
                table: "Submissions",
                newName: "IX_Submissions_AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Assignments_AssignmentId",
                table: "Submissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Assignments_AssignmentId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "Submissions",
                newName: "AssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_AssignmentId",
                table: "Submissions",
                newName: "IX_Submissions_AssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Assignments_AssignmentID",
                table: "Submissions",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
