using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    ChecklistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.ChecklistId);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    DateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.DateId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlusOneId = table.Column<int>(type: "int", nullable: true),
                    ExtraRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guests_Guests_PlusOneId",
                        column: x => x.PlusOneId,
                        principalTable: "Guests",
                        principalColumn: "GuestId");
                });

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

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "DietaryNeeds",
                columns: table => new
                {
                    DietNeedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    Restrictions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryNeeds", x => x.DietNeedId);
                    table.ForeignKey(
                        name: "FK_DietaryNeeds_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatingChart",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    YCoord = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    XCoord = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatingChart", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_SeatingChart_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatingChart_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_DietaryNeeds_GuestId",
                table: "DietaryNeeds",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PlusOneId",
                table: "Guests",
                column: "PlusOneId",
                unique: true,
                filter: "[PlusOneId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SeatingChart_GuestId",
                table: "SeatingChart",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatingChart_TableId",
                table: "SeatingChart",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checklists");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "DietaryNeeds");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "SeatingChart");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
