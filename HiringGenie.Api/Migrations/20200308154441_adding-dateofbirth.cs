using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiringGenie.Api.Migrations
{
    public partial class addingdateofbirth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Applications",
                newName: "DisplayPicture");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "DisplayPicture",
                table: "Applications",
                newName: "FileType");
        }
    }
}
