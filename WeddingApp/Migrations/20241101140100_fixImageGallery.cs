using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class fixImageGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStart",
                table: "Dates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateName",
                table: "Dates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEnd",
                table: "Dates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "GalleryImages",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.PictureId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryImages");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStart",
                table: "Dates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateName",
                table: "Dates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEnd",
                table: "Dates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "PictureId", "Url" },
                values: new object[,]
                {
                    { 1, "Images\\IMG_0629.JPG" },
                    { 2, "Images\\IMG_0630.JPG" },
                    { 3, "Images\\IMG_1540.JPG" },
                    { 4, "Images\\IMG_2702.JPG" },
                    { 5, "Images\\IMG_2708.JPG" },
                    { 6, "Images\\IMG_2714.JPG" },
                    { 7, "Images\\IMG_3218.JPG" },
                    { 8, "Images\\IMG_3271.JPG" },
                    { 9, "Images\\IMG_3285.JPG" },
                    { 10, "Images\\IMG_3291.JPG" },
                    { 11, "Images\\IMG_3309.JPG" },
                    { 12, "Images\\IMG_4107.JPG" },
                    { 13, "Images\\IMG_4370.JPG" },
                    { 14, "Images\\IMG_4390.JPG" },
                    { 15, "Images\\OXLZ6554.JPG" },
                    { 16, "Images\\SIAM0204.JPG" }
                });
        }
    }
}
