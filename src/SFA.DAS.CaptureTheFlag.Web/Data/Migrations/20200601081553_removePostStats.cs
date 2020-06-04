using Microsoft.EntityFrameworkCore.Migrations;

namespace DAS_Capture_The_Flag.Data.Migrations
{
    public partial class removePostStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostStats",
                table: "Forums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostStats",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
