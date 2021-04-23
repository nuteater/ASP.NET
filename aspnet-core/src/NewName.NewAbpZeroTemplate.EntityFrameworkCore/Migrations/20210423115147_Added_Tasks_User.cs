using Microsoft.EntityFrameworkCore.Migrations;

namespace NewName.NewAbpZeroTemplate.Migrations
{
    public partial class Added_Tasks_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    TTTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_TTTasks_TTTaskId",
                        column: x => x.TTTaskId,
                        principalTable: "TTTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Users_TenantId",
                table: "Tasks_Users",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Users_TTTaskId",
                table: "Tasks_Users",
                column: "TTTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Users_UserId",
                table: "Tasks_Users",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks_Users");
        }
    }
}
