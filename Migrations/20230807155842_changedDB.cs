using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid19ProjectAPI.Migrations
{
    public partial class changedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    countryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    totalCasesReported = table.Column<double>(type: "float", nullable: true),
                    totalActiveCases = table.Column<double>(type: "float", nullable: true),
                    totalDeaths = table.Column<double>(type: "float", nullable: true),
                    totalCuredCases = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "loginUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registerUsers",
                columns: table => new
                {
                    registerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registerUsers", x => x.registerId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    totalCasesReported = table.Column<double>(type: "float", nullable: true),
                    totalActiveCases = table.Column<double>(type: "float", nullable: true),
                    totalDeaths = table.Column<double>(type: "float", nullable: true),
                    totalCuredCases = table.Column<double>(type: "float", nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityId);
                    table.ForeignKey(
                        name: "FK_cities_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "countryId");
                });

            migrationBuilder.CreateTable(
                name: "usersWishlist",
                columns: table => new
                {
                    wishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wishListCountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersuserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersWishlist", x => x.wishlistId);
                    table.ForeignKey(
                        name: "FK_usersWishlist_countries_countryId",
                        column: x => x.countryId,
                        principalTable: "countries",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersWishlist_users_UsersuserId",
                        column: x => x.UsersuserId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "casesInCities",
                columns: table => new
                {
                    caseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    inactiveOrdeath = table.Column<bool>(type: "bit", nullable: false),
                    cured = table.Column<bool>(type: "bit", nullable: false),
                    dateRegistered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_casesInCities", x => x.caseId);
                    table.ForeignKey(
                        name: "FK_casesInCities_cities_cityId",
                        column: x => x.cityId,
                        principalTable: "cities",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_casesInCities_cityId",
                table: "casesInCities",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_usersWishlist_countryId",
                table: "usersWishlist",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_usersWishlist_UsersuserId",
                table: "usersWishlist",
                column: "UsersuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "casesInCities");

            migrationBuilder.DropTable(
                name: "loginUsers");

            migrationBuilder.DropTable(
                name: "registerUsers");

            migrationBuilder.DropTable(
                name: "usersWishlist");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
