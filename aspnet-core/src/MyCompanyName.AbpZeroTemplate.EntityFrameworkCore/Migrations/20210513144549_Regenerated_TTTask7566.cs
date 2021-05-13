using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Regenerated_TTTask7566 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubtaskId",
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

            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "TTTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_SubtaskId",
                table: "TTTasks",
                column: "SubtaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_TaskHistoryId",
                table: "TTTasks",
                column: "TaskHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_TaskPriorityId",
                table: "TTTasks",
                column: "TaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_TaskTypeId",
                table: "TTTasks",
                column: "TaskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TTTasks_Subtasks_SubtaskId",
                table: "TTTasks",
                column: "SubtaskId",
                principalTable: "Subtasks",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TTTasks_TaskTypes_TaskTypeId",
                table: "TTTasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_Subtasks_SubtaskId",
                table: "TTTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_TaskHistories_TaskHistoryId",
                table: "TTTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_TaskPriorities_TaskPriorityId",
                table: "TTTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TTTasks_TaskTypes_TaskTypeId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_SubtaskId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_TaskHistoryId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_TaskPriorityId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_TaskTypeId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "SubtaskId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TaskHistoryId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TaskPriorityId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "TTTasks");
        }
    }
}
