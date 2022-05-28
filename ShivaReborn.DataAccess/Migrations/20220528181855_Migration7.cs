using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShivaReborn.DataAccess.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "dates",
                table: "Places",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "usersId",
                table: "Places",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dates",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "Places");
        }
    }
}
