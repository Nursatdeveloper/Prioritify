using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prioritify.Data.Migrations.UserDb
{
    public partial class AddedUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "tbaccounts",
                schema: "users",
                columns: table => new
                {
                    flAccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flUserId = table.Column<int>(type: "integer", nullable: false),
                    flUsername = table.Column<string>(type: "text", nullable: false),
                    flEmail = table.Column<string>(type: "text", nullable: false),
                    flPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    flPassword = table.Column<string>(type: "text", nullable: false),
                    flCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    flUpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbaccounts", x => x.flAccountId);
                });

            migrationBuilder.CreateTable(
                name: "tbroles",
                schema: "users",
                columns: table => new
                {
                    flRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flRole = table.Column<int>(type: "integer", nullable: false),
                    flCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    flUpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbroles", x => x.flRoleId);
                });

            migrationBuilder.CreateTable(
                name: "tbuserroles",
                schema: "users",
                columns: table => new
                {
                    flId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flUserId = table.Column<int>(type: "integer", nullable: false),
                    flAccountId = table.Column<int>(type: "integer", nullable: false),
                    flRoleId = table.Column<int>(type: "integer", nullable: false),
                    flCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    flUpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbuserroles", x => x.flId);
                });

            migrationBuilder.CreateTable(
                name: "tbusers",
                schema: "users",
                columns: table => new
                {
                    flUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flFirstname = table.Column<string>(type: "text", nullable: false),
                    flLastname = table.Column<string>(type: "text", nullable: false),
                    flBirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    flGender = table.Column<int>(type: "integer", nullable: false),
                    flStudyYear = table.Column<int>(type: "integer", nullable: false),
                    flDegree = table.Column<int>(type: "integer", nullable: false),
                    flCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    flUpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbusers", x => x.flUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbaccounts",
                schema: "users");

            migrationBuilder.DropTable(
                name: "tbroles",
                schema: "users");

            migrationBuilder.DropTable(
                name: "tbuserroles",
                schema: "users");

            migrationBuilder.DropTable(
                name: "tbusers",
                schema: "users");
        }
    }
}
