using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShivaReborn.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    Buildingid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_Buildingid",
                        column: x => x.Buildingid,
                        principalTable: "Buildings",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    buildingid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Buildings_buildingid",
                        column: x => x.buildingid,
                        principalTable: "Buildings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    isAssigned = table.Column<bool>(type: "boolean", nullable: false),
                    User = table.Column<string>(type: "text", nullable: true),
                    Floorid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.id);
                    table.ForeignKey(
                        name: "FK_Places_Floors_Floorid",
                        column: x => x.Floorid,
                        principalTable: "Floors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Places_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floors_Buildingid",
                table: "Floors",
                column: "Buildingid");

            migrationBuilder.CreateIndex(
                name: "IX_Places_Floorid",
                table: "Places",
                column: "Floorid");

            migrationBuilder.CreateIndex(
                name: "IX_Places_User",
                table: "Places",
                column: "User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_buildingid",
                table: "Users",
                column: "buildingid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
