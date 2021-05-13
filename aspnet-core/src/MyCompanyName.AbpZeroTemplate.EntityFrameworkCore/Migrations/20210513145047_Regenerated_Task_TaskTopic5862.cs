using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Regenerated_Task_TaskTopic5862 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Task_TaskTopics");

            migrationBuilder.DropColumn(
                name: "TopikId",
                table: "Task_TaskTopics");

            migrationBuilder.AddColumn<int>(
                name: "TTTaskId",
                table: "Task_TaskTopics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskTopicId",
                table: "Task_TaskTopics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTopics_TaskTopicId",
                table: "Task_TaskTopics",
                column: "TaskTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTopics_TTTaskId",
                table: "Task_TaskTopics",
                column: "TTTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskTopics_TaskTopics_TaskTopicId",
                table: "Task_TaskTopics",
                column: "TaskTopicId",
                principalTable: "TaskTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskTopics_TTTasks_TTTaskId",
                table: "Task_TaskTopics",
                column: "TTTaskId",
                principalTable: "TTTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskTopics_TaskTopics_TaskTopicId",
                table: "Task_TaskTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskTopics_TTTasks_TTTaskId",
                table: "Task_TaskTopics");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskTopics_TaskTopicId",
                table: "Task_TaskTopics");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskTopics_TTTaskId",
                table: "Task_TaskTopics");

            migrationBuilder.DropColumn(
                name: "TTTaskId",
                table: "Task_TaskTopics");

            migrationBuilder.DropColumn(
                name: "TaskTopicId",
                table: "Task_TaskTopics");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Task_TaskTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TopikId",
                table: "Task_TaskTopics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
