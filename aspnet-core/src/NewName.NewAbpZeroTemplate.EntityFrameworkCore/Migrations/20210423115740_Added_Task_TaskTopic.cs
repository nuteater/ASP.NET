using Microsoft.EntityFrameworkCore.Migrations;

namespace NewName.NewAbpZeroTemplate.Migrations
{
    public partial class Added_Task_TaskTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task_TaskTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    TaskTopicId = table.Column<int>(type: "int", nullable: true),
                    TTTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_TaskTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_TaskTopics_TaskTopics_TaskTopicId",
                        column: x => x.TaskTopicId,
                        principalTable: "TaskTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_TaskTopics_TTTasks_TTTaskId",
                        column: x => x.TTTaskId,
                        principalTable: "TTTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTopics_TaskTopicId",
                table: "Task_TaskTopics",
                column: "TaskTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTopics_TenantId",
                table: "Task_TaskTopics",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTopics_TTTaskId",
                table: "Task_TaskTopics",
                column: "TTTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task_TaskTopics");
        }
    }
}
