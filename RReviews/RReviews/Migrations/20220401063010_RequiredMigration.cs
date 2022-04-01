using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RReviews.Migrations
{
    public partial class RequiredMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Image",
                newName: "RelativePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelativePath",
                table: "Image",
                newName: "Url");
        }
    }
}
