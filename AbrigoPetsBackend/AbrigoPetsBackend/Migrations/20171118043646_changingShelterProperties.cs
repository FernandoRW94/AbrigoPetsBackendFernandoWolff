using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbrigoPetsBackend.Migrations
{
    public partial class changingShelterProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAnimals",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "TotalCats",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "TotalDogs",
                table: "Shelters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalAnimals",
                table: "Shelters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCats",
                table: "Shelters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalDogs",
                table: "Shelters",
                nullable: false,
                defaultValue: 0);
        }
    }
}
