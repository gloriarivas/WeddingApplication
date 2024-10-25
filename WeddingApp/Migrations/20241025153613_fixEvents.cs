using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingApp.Migrations
{
    /// <inheritdoc />
    public partial class fixEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSpaceTypes");

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "EventSpaces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSpaces_EventTypeId",
                table: "EventSpaces",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSpaces_EventTypes_EventTypeId",
                table: "EventSpaces",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "EventTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventSpaces_EventTypes_EventTypeId",
                table: "EventSpaces");

            migrationBuilder.DropIndex(
                name: "IX_EventSpaces_EventTypeId",
                table: "EventSpaces");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "EventSpaces");

            migrationBuilder.CreateTable(
                name: "EventSpaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_EventSpaceTypes_SpaceId",
                table: "EventSpaceTypes",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpaceTypes_TypeId",
                table: "EventSpaceTypes",
                column: "TypeId");
        }
    }
}
