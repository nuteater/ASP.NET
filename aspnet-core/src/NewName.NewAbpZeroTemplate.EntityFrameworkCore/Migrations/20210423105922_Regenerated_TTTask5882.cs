using Microsoft.EntityFrameworkCore.Migrations;

namespace NewName.NewAbpZeroTemplate.Migrations
{
    public partial class Regenerated_TTTask5882 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "PriorityID",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "SubtaskId",
                table: "TTTasks");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "TTTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TTTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityID",
                table: "TTTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubtaskId",
                table: "TTTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "TTTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
