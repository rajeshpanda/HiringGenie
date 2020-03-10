using Microsoft.EntityFrameworkCore.Migrations;

namespace HiringGenie.Api.Migrations
{
    public partial class addingvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Scheduler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordedAudioPath",
                table: "Interview",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Scheduler");

            migrationBuilder.DropColumn(
                name: "RecordedAudioPath",
                table: "Interview");
        }
    }
}
