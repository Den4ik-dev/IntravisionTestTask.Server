using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDrinkEntityAndCreateDrinkComplexProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drinks");

            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "drink_lines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "drink_lines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "drink_lines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_drink_lines_image_path",
                table: "drink_lines",
                column: "image_path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drink_lines_name",
                table: "drink_lines",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_drink_lines_image_path",
                table: "drink_lines");

            migrationBuilder.DropIndex(
                name: "IX_drink_lines_name",
                table: "drink_lines");

            migrationBuilder.DropColumn(
                name: "image_path",
                table: "drink_lines");

            migrationBuilder.DropColumn(
                name: "name",
                table: "drink_lines");

            migrationBuilder.DropColumn(
                name: "price",
                table: "drink_lines");

            migrationBuilder.CreateTable(
                name: "drinks",
                columns: table => new
                {
                    drink_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    drink_line_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinks", x => x.drink_id);
                    table.ForeignKey(
                        name: "FK_drinks_drink_lines_drink_line_id",
                        column: x => x.drink_line_id,
                        principalTable: "drink_lines",
                        principalColumn: "drink_line_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drinks_drink_line_id",
                table: "drinks",
                column: "drink_line_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drinks_image_path",
                table: "drinks",
                column: "image_path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drinks_name",
                table: "drinks",
                column: "name",
                unique: true);
        }
    }
}
