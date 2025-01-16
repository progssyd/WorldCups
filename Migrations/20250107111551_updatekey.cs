using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCups.Migrations
{
    /// <inheritdoc />
    public partial class updatekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transports_transportations_CategorisTransportation",
                table: "transports");

            migrationBuilder.DropIndex(
                name: "IX_transports_CategorisTransportation",
                table: "transports");

            migrationBuilder.RenameColumn(
                name: "CategorisTransportation",
                table: "transports",
                newName: "vehicle");

            migrationBuilder.AddColumn<int>(
                name: "CategorisTransportationId",
                table: "transports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_transports_CategorisTransportationId",
                table: "transports",
                column: "CategorisTransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_transports_transportations_CategorisTransportationId",
                table: "transports",
                column: "CategorisTransportationId",
                principalTable: "transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transports_transportations_CategorisTransportationId",
                table: "transports");

            migrationBuilder.DropIndex(
                name: "IX_transports_CategorisTransportationId",
                table: "transports");

            migrationBuilder.DropColumn(
                name: "CategorisTransportationId",
                table: "transports");

            migrationBuilder.RenameColumn(
                name: "vehicle",
                table: "transports",
                newName: "CategorisTransportation");

            migrationBuilder.CreateIndex(
                name: "IX_transports_CategorisTransportation",
                table: "transports",
                column: "CategorisTransportation");

            migrationBuilder.AddForeignKey(
                name: "FK_transports_transportations_CategorisTransportation",
                table: "transports",
                column: "CategorisTransportation",
                principalTable: "transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
