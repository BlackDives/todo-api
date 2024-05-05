using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class AnothaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTags_UserTasks_UserTaskId",
                table: "TaskTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_UserId",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTasks",
                table: "UserTasks");

            migrationBuilder.RenameTable(
                name: "UserTasks",
                newName: "todo.user-tasks");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "todo.user-tasks",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "todo.user-tasks",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "todo.user-tasks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "todo.user-tasks",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "todo.user-tasks",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "todo.user-tasks",
                newName: "task_name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "todo.user-tasks",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "todo.user-tasks",
                newName: "task_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId",
                table: "todo.user-tasks",
                newName: "IX_todo.user-tasks_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todo.user-tasks",
                table: "todo.user-tasks",
                column: "task_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTags_todo.user-tasks_UserTaskId",
                table: "TaskTags",
                column: "UserTaskId",
                principalTable: "todo.user-tasks",
                principalColumn: "task_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_todo.user-tasks_Users_user_id",
                table: "todo.user-tasks",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTags_todo.user-tasks_UserTaskId",
                table: "TaskTags");

            migrationBuilder.DropForeignKey(
                name: "FK_todo.user-tasks_Users_user_id",
                table: "todo.user-tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todo.user-tasks",
                table: "todo.user-tasks");

            migrationBuilder.RenameTable(
                name: "todo.user-tasks",
                newName: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "UserTasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "UserTasks",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "UserTasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserTasks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "UserTasks",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "task_name",
                table: "UserTasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "UserTasks",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "task_id",
                table: "UserTasks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_todo.user-tasks_user_id",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTasks",
                table: "UserTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTags_UserTasks_UserTaskId",
                table: "TaskTags",
                column: "UserTaskId",
                principalTable: "UserTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
