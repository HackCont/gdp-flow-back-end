using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GdpFlow.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class PdisMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pdi_Users_UserId",
                table: "Pdi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pdi",
                table: "Pdi");

            migrationBuilder.RenameTable(
                name: "Pdi",
                newName: "Pdis");

            migrationBuilder.RenameIndex(
                name: "IX_Pdi_UserId",
                table: "Pdis",
                newName: "IX_Pdis_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pdis",
                table: "Pdis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pdis_Users_UserId",
                table: "Pdis",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pdis_Users_UserId",
                table: "Pdis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pdis",
                table: "Pdis");

            migrationBuilder.RenameTable(
                name: "Pdis",
                newName: "Pdi");

            migrationBuilder.RenameIndex(
                name: "IX_Pdis_UserId",
                table: "Pdi",
                newName: "IX_Pdi_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pdi",
                table: "Pdi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pdi_Users_UserId",
                table: "Pdi",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
