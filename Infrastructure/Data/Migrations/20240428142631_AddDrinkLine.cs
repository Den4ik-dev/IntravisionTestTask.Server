using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDrinkLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity_in_machine",
                table: "drinks");

            migrationBuilder.AddColumn<Guid>(
                name: "drink_line_id",
                table: "drinks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "drink_lines",
                columns: table => new
                {
                    drink_line_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    drinks_quantity_in_machine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drink_lines", x => x.drink_line_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drinks_drink_line_id",
                table: "drinks",
                column: "drink_line_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_drinks_drink_lines_drink_line_id",
                table: "drinks",
                column: "drink_line_id",
                principalTable: "drink_lines",
                principalColumn: "drink_line_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drinks_drink_lines_drink_line_id",
                table: "drinks");

            migrationBuilder.DropTable(
                name: "drink_lines");

            migrationBuilder.DropIndex(
                name: "IX_drinks_drink_line_id",
                table: "drinks");

            migrationBuilder.DropColumn(
                name: "drink_line_id",
                table: "drinks");

            migrationBuilder.AddColumn<int>(
                name: "quantity_in_machine",
                table: "drinks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
