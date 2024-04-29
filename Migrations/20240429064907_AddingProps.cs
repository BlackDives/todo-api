using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class AddingProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTags_UserTasks_TaskIdId",
                table: "TaskTags");

            migrationBuilder.RenameColumn(
                name: "TaskIdId",
                table: "TaskTags",
                newName: "UserTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskTags_TaskIdId",
                table: "TaskTags",
                newName: "IX_TaskTags_UserTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTags_UserTasks_UserTaskId",
                table: "TaskTags",
                column: "UserTaskId",
                principalTable: "UserTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTags_UserTasks_UserTaskId",
                table: "TaskTags");

            migrationBuilder.RenameColumn(
                name: "UserTaskId",
                table: "TaskTags",
                newName: "TaskIdId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskTags_UserTaskId",
                table: "TaskTags",
                newName: "IX_TaskTags_TaskIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTags_UserTasks_TaskIdId",
                table: "TaskTags",
                column: "TaskIdId",
                principalTable: "UserTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
