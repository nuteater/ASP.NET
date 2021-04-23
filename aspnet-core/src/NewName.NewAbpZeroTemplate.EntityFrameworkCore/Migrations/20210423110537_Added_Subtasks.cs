using Microsoft.EntityFrameworkCore.Migrations;

namespace NewName.NewAbpZeroTemplate.Migrations
{
    public partial class Added_Subtasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subtaskses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtaskses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subtaskses_TenantId",
                table: "Subtaskses",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subtaskses");
        }
    }
}
