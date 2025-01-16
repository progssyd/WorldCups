﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCups.Migrations
{
    /// <inheritdoc />
    public partial class addpath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path",
                table: "categories");
        }
    }
}
