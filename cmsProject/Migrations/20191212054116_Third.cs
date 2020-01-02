using Microsoft.EntityFrameworkCore.Migrations;

namespace cmsProject.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posts",
                table: "Contents");

            migrationBuilder.AddColumn<string>(
                name: "ContentBody",
                table: "Contents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentHeader",
                table: "Contents",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentBody",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "ContentHeader",
                table: "Contents");

            migrationBuilder.AddColumn<string>(
                name: "Posts",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
