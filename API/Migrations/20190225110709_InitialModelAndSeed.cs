using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStore.Migrations
{
    public partial class InitialModelAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LockerBanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LockerBanks_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LockerBankId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lockers_LockerBanks_LockerBankId",
                        column: x => x.LockerBankId,
                        principalTable: "LockerBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sydney" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Melbourne" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Brisbane" });

            migrationBuilder.InsertData(
                table: "LockerBanks",
                columns: new[] { "Id", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "cbd_lockerbank_1" },
                    { 2, 1, "manly_lockerbank_2" },
                    { 3, 1, "terrey_Hills_lockerbank_3" },
                    { 4, 2, "cbd_lockerbank_1" },
                    { 5, 2, "southbank_lockerbank_2" },
                    { 6, 3, "cbd_lockerbank_1" },
                    { 7, 3, "south_brisbane_lockerbank_2" }
                });

            migrationBuilder.InsertData(
                table: "Lockers",
                columns: new[] { "Id", "LockerBankId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "L1" },
                    { 23, 7, "L2" },
                    { 22, 7, "L1" },
                    { 21, 6, "L4" },
                    { 20, 6, "L3" },
                    { 19, 6, "L2" },
                    { 18, 6, "L1" },
                    { 17, 5, "L3" },
                    { 16, 5, "L2" },
                    { 15, 5, "L1" },
                    { 14, 4, "L3" },
                    { 24, 7, "L3" },
                    { 13, 4, "L2" },
                    { 11, 3, "L3" },
                    { 10, 3, "L2" },
                    { 9, 3, "L1" },
                    { 8, 2, "L3" },
                    { 7, 2, "L2" },
                    { 6, 2, "L1" },
                    { 5, 1, "L5" },
                    { 4, 1, "L4" },
                    { 3, 1, "L3" },
                    { 2, 1, "L2" },
                    { 12, 4, "L1" },
                    { 25, 7, "L4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LockerBanks_LocationId",
                table: "LockerBanks",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lockers_LockerBankId",
                table: "Lockers",
                column: "LockerBankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lockers");

            migrationBuilder.DropTable(
                name: "LockerBanks");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
