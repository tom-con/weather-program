using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sovosweather.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AveragedDatum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AverageHighTemp = table.Column<decimal>(nullable: false),
                    AverageLowTemp = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AveragedDatum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WeatherDatum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HighTemp = table.Column<decimal>(nullable: false),
                    LowTemp = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDatum", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AveragedDatum");

            migrationBuilder.DropTable(
                name: "WeatherDatum");
        }
    }
}
