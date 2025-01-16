using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCups.Migrations
{
    /// <inheritdoc />
    public partial class k2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transports_transportations_CategorisTransportationId",
                table: "transports");

            migrationBuilder.DropIndex(
                name: "IX_transports_CategorisTransportationId",
                table: "transports");

            migrationBuilder.DropColumn(
                name: "vehicle",
                table: "transports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vehicle",
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
    }
}
