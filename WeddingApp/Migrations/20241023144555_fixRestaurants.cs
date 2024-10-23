using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class fixRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoursLunch",
                table: "Restaurants",
                newName: "HoursLunchStart");

            migrationBuilder.RenameColumn(
                name: "HoursDinner",
                table: "Restaurants",
                newName: "HoursLunchEnd");

            migrationBuilder.RenameColumn(
                name: "HoursBreakfast",
                table: "Restaurants",
                newName: "HoursDinnerStart");

            migrationBuilder.AddColumn<string>(
                name: "HoursBreakfastEnd",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoursBreakfastStart",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoursDinnerEnd",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursBreakfastEnd",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HoursBreakfastStart",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HoursDinnerEnd",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "HoursLunchStart",
                table: "Restaurants",
                newName: "HoursLunch");

            migrationBuilder.RenameColumn(
                name: "HoursLunchEnd",
                table: "Restaurants",
                newName: "HoursDinner");

            migrationBuilder.RenameColumn(
                name: "HoursDinnerStart",
                table: "Restaurants",
                newName: "HoursBreakfast");
        }
    }
}
