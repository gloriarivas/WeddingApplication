using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class restaurantsInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    BarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursStart = table.Column<double>(type: "float", nullable: true),
                    HoursEnd = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.BarId);
                });

            migrationBuilder.CreateTable(
                name: "DressCode",
                columns: table => new
                {
                    DressCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannedItems = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressCode", x => x.DressCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuisineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DressCodeId = table.Column<int>(type: "int", nullable: true),
                    HoursStart = table.Column<double>(type: "float", nullable: true),
                    HoursEnd = table.Column<double>(type: "float", nullable: true),
                    HasBreakfastHours = table.Column<bool>(type: "bit", nullable: false),
                    BreakfastHoursStart = table.Column<double>(type: "float", nullable: true),
                    BreakfastHoursEnd = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurants_DressCode_DressCodeId",
                        column: x => x.DressCodeId,
                        principalTable: "DressCode",
                        principalColumn: "DressCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_DressCodeId",
                table: "Restaurants",
                column: "DressCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "DressCode");
        }
    }
}
