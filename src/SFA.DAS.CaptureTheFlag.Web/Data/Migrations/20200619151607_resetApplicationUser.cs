using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAS_Capture_The_Flag.Data.Migrations
{
    public partial class resetApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPostDate",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "LastPoster",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "LastTopicTitle",
                table: "Forums");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPostDate",
                table: "Forums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastPoster",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastTopicTitle",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
