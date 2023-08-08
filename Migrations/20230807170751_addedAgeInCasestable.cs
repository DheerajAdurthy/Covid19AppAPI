using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid19ProjectAPI.Migrations
{
    public partial class addedAgeInCasestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "casesInCities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "casesInCities");
        }
    }
}
