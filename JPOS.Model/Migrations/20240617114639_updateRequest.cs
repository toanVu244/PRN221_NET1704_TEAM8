using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPOS.Model.Migrations
{
    public partial class updateRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Requests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Requests");
        }
    }
}
