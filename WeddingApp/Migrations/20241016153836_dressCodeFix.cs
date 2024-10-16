using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class dressCodeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DressCode",
                newName: "DescriptionWomen");

            migrationBuilder.RenameColumn(
                name: "BannedItems",
                table: "DressCode",
                newName: "DescriptionMen");

            migrationBuilder.AddColumn<string>(
                name: "BannedItemsMen",
                table: "DressCode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannedItemsWomen",
                table: "DressCode",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannedItemsMen",
                table: "DressCode");

            migrationBuilder.DropColumn(
                name: "BannedItemsWomen",
                table: "DressCode");

            migrationBuilder.RenameColumn(
                name: "DescriptionWomen",
                table: "DressCode",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DescriptionMen",
                table: "DressCode",
                newName: "BannedItems");
        }
    }
}
