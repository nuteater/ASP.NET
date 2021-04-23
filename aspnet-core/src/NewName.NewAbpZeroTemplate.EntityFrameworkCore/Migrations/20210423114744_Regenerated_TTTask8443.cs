using Microsoft.EntityFrameworkCore.Migrations;

namespace NewName.NewAbpZeroTemplate.Migrations
{
    public partial class Regenerated_TTTask8443 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubtasksId",
                table: "TTTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskHistoryId",
                table: "TTTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskPriorityId",
                table: "TTTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_SubtasksId",
                table: "TTTasks",
                column: "SubtasksId");

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_TaskHistoryId",
                table: "TTTasks",
                column: "TaskHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_TaskPriorityId",
                table: "TTTasks",
                column: "TaskPriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TTTasks_Subtaskses_SubtasksId",
                table: "TTTasks",
                column: "SubtasksId",
                principalTable: "Subtaskses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TTTasks_TaskHistories_TaskHistoryId",
                table: "TTTasks",
                column: "TaskHistoryId",
                principalTable: "TaskHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TTTasks_TaskPriorities_TaskPriorityId",
                table: "TTTasks",
                column: "TaskPriorityId",
                principalTable: "TaskPriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_Subtaskses_SubtasksId",
                table: "TTTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_TaskHistories_TaskHistoryId",
                table: "TTTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_TaskPriorities_TaskPriorityId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_SubtasksId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_TaskHistoryId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_TaskPriorityId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "SubtasksId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TaskHistoryId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TaskPriorityId",
                table: "TTTasks");
        }
    }
}
