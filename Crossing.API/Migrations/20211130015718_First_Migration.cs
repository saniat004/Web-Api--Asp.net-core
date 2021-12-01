using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crossing.API.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorderGates",
                columns: table => new
                {
                    Destination = table.Column<string>(maxLength: 50, nullable: false),
                    List = table.Column<string>(maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorderGates", x => x.Destination);
                    table.ForeignKey(
                        name: "FK_BorderGates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CAN" },
                    { 2, "USA" },
                    { 3, "MEX" },
                    { 4, "BLZ" },
                    { 5, "GTM" },
                    { 6, "SLV" },
                    { 7, "HND" },
                    { 8, "NIC" },
                    { 9, "CRI" },
                    { 10, "PAN" }
                });

            migrationBuilder.InsertData(
                table: "BorderGates",
                columns: new[] { "Destination", "CountryId", "List" },
                values: new object[,]
                {
                    { "CAN", 1, "[USA]" },
                    { "USA", 2, "[CAN]" },
                    { "MEX", 3, "[USA]" },
                    { "BLZ", 4, "[USA , MEX , BLZ ]" },
                    { "GTM", 5, "[USA , MEX , GTM ]" },
                    { "SLV", 6, "[USA , MEX , GTM , SLV ]" },
                    { "HND", 7, "[USA , MEX , GTM , HND ]" },
                    { "NIC", 8, "[USA , MEX , GTM , HND , NIC ]" },
                    { "CRI", 9, "[ USA ,MEX , GTM , HND , NIC , CRI ]" },
                    { "PAN", 10, "[ USA ,MEX , GTM , HND , NIC , CRI , PAN ]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorderGates_CountryId",
                table: "BorderGates",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorderGates");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
