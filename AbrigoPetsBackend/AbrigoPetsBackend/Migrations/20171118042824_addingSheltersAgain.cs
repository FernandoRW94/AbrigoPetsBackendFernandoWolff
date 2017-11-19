using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbrigoPetsBackend.Migrations
{
    public partial class addingSheltersAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    ShelterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastExpense = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LastRevenue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ShelterMoney = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ShelterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAnimals = table.Column<int>(type: "int", nullable: false),
                    TotalCats = table.Column<int>(type: "int", nullable: false),
                    TotalDogs = table.Column<int>(type: "int", nullable: false),
                    TotalFood = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.ShelterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
