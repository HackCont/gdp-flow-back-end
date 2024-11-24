using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GdpFlow.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPdiTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pdi",
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
                    table.PrimaryKey("PK_Pdi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pdi_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pdi_UserId",
                table: "Pdi",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pdi");
        }
    }
}
