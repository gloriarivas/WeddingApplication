using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class fixRestaurantHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakfastHoursEnd",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "BreakfastHoursStart",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HasBreakfastHours",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HoursEnd",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HoursStart",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "HoursBreakfast",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoursDinner",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoursLunch",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursBreakfast",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HoursDinner",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HoursLunch",
                table: "Restaurants");

            migrationBuilder.AddColumn<double>(
                name: "BreakfastHoursEnd",
                table: "Restaurants",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BreakfastHoursStart",
                table: "Restaurants",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBreakfastHours",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "HoursEnd",
                table: "Restaurants",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HoursStart",
                table: "Restaurants",
                type: "float",
                nullable: true);
        }
    }
}
