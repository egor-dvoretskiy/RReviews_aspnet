using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RReviews.Migrations
{
    public partial class ObjectNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TestingDate",
                table: "Review",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ObjectName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectName",
                table: "Review");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TestingDate",
                table: "Review",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
