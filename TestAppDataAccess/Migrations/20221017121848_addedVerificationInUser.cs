using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppDataAccess.Migrations
{
    public partial class addedVerificationInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedOn",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerifiedOn",
                table: "Users");
        }
    }
}
