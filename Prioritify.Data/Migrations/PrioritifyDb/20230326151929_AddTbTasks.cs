using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prioritify.Data.Migrations.PrioritifyDb
{
    public partial class AddTbTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.CreateTable(
                name: "tbtasks",
                schema: "application",
                columns: table => new
                {
                    flId = table.Column<string>(type: "text", nullable: false),
                    flName = table.Column<string>(type: "text", nullable: false),
                    flDescription = table.Column<string>(type: "text", nullable: false),
                    flDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    flUserId = table.Column<int>(type: "integer", nullable: false),
                    flStatus = table.Column<int>(type: "integer", nullable: false),
                    flPrevVersionsInJson = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbtasks", x => x.flId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbtasks",
                schema: "application");
        }
    }
}
