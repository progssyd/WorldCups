using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCups.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tableFootbuls_stadiums_Stadiums",
                table: "tableFootbuls");

            migrationBuilder.DropIndex(
                name: "IX_tableFootbuls_Stadiums",
                table: "tableFootbuls");

            migrationBuilder.RenameColumn(
                name: "Stadiums",
                table: "tableFootbuls",
                newName: "Stadiums_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stadiums_id",
                table: "tableFootbuls",
                newName: "Stadiums");

            migrationBuilder.CreateIndex(
                name: "IX_tableFootbuls_Stadiums",
                table: "tableFootbuls",
                column: "Stadiums");

            migrationBuilder.AddForeignKey(
                name: "FK_tableFootbuls_stadiums_Stadiums",
                table: "tableFootbuls",
                column: "Stadiums",
                principalTable: "stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
