using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoLounge.Migrations
{
    /// <inheritdoc />
    public partial class updatedentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondoNumber = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condos_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserCondo",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<int>(type: "int", nullable: false),
                    CondosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCondo", x => new { x.ApplicationUsersId, x.CondosId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCondo_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCondo_Condos_CondosId",
                        column: x => x.CondosId,
                        principalTable: "Condos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCondo_CondosId",
                table: "ApplicationUserCondo",
                column: "CondosId");

            migrationBuilder.CreateIndex(
                name: "IX_Condos_BuildingId",
                table: "Condos",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserCondo");

            migrationBuilder.DropTable(
                name: "Condos");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
