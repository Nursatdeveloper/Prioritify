using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prioritify.Data.Migrations
{
    public partial class SystemTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.CreateTable(
                name: "tbexceptions",
                schema: "system",
                columns: table => new
                {
                    flExceptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flCreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    flException = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbexceptions", x => x.flExceptionId);
                });

            migrationBuilder.CreateTable(
                name: "tblogs",
                schema: "system",
                columns: table => new
                {
                    flLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flType = table.Column<string>(type: "text", nullable: false),
                    flMessage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblogs", x => x.flLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbexceptions",
                schema: "system");

            migrationBuilder.DropTable(
                name: "tblogs",
                schema: "system");
        }
    }
}
