using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GdpFlow.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    First_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Skills = table.Column<string>(type: "text", nullable: true),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pdis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Start_Doing = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Stop_Doing = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Do_Less = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Keep_Doing = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Do_More = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Goal = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pdis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moments_UserId",
                table: "Moments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pdis_UserId",
                table: "Pdis",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moments");

            migrationBuilder.DropTable(
                name: "Pdis");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
