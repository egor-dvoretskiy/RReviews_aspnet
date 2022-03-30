using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RReviews.Migrations
{
    public partial class ReviewTypeObjectMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewTypeObject",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewTypeObject",
                table: "Review");
        }
    }
}
