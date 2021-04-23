using Microsoft.EntityFrameworkCore.Migrations;

namespace NewName.NewAbpZeroTemplate.Migrations
{
    public partial class Regenerated_TTTask1690 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "TTTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TTTasks_TaskTypeId",
                table: "TTTasks",
                column: "TaskTypeId");

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
                name: "FK_TTTasks_TaskTypes_TaskTypeId",
                table: "TTTasks");

            migrationBuilder.DropIndex(
                name: "IX_TTTasks_TaskTypeId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "TTTasks");
        }
    }
}
