using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prioritify.Data.Migrations.UserDb
{
    public partial class AddedTbUsersOpsAndTbAccountsOps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbaccountsops",
                schema: "users",
                columns: table => new
                {
                    flOperationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flOpType = table.Column<string>(type: "text", nullable: false),
                    flOpModelJson = table.Column<string>(type: "text", nullable: false),
                    flTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    flStatus = table.Column<int>(type: "integer", nullable: false),
                    flExecuter = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbaccountsops", x => x.flOperationId);
                });

            migrationBuilder.CreateTable(
                name: "tbusersops",
                schema: "users",
                columns: table => new
                {
                    flOperationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flOpType = table.Column<string>(type: "text", nullable: false),
                    flOpModelJson = table.Column<string>(type: "text", nullable: false),
                    flTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    flStatus = table.Column<int>(type: "integer", nullable: false),
                    flExecuter = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbusersops", x => x.flOperationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbaccountsops",
                schema: "users");

            migrationBuilder.DropTable(
                name: "tbusersops",
                schema: "users");
        }
    }
}
