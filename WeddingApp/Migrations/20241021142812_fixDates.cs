using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class fixDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ExtraRole",
            //    table: "Guests");

            migrationBuilder.AddColumn<string>(
                name: "DateName",
                table: "Dates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateName",
                table: "Dates");

            migrationBuilder.AddColumn<string>(
                name: "ExtraRole",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
