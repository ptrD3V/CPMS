using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.DAL.Migrations
{
    public partial class developers_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "cpms",
                table: "Developers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "cpms",
                table: "Developers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "cpms",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "cpms",
                table: "Developers");
        }
    }
}
