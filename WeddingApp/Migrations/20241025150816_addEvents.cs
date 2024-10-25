using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class addEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventSpaces",
                columns: table => new
                {
                    EventSpaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventSpaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGuests = table.Column<int>(type: "int", nullable: true),
                    MaxGuests = table.Column<int>(type: "int", nullable: true),
                    BookingFee = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSpaces", x => x.EventSpaceId);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EventSpaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    SpaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSpaceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSpaceTypes_EventSpaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "EventSpaces",
                        principalColumn: "EventSpaceId");
                    table.ForeignKey(
                        name: "FK_EventSpaceTypes_EventTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId");
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "TypeName" },
                values: new object[,]
                {
                    { 100, "Ceremony" },
                    { 101, "Cocktail" },
                    { 102, "Reception" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSpaceTypes_SpaceId",
                table: "EventSpaceTypes",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpaceTypes_TypeId",
                table: "EventSpaceTypes",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSpaceTypes");

            migrationBuilder.DropTable(
                name: "EventSpaces");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
