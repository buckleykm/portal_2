using Microsoft.EntityFrameworkCore.Migrations;

namespace portal_2.API.Migrations
{
    public partial class AddedPremiumToApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "premium",
                table: "Apps",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "premium",
                table: "Apps");
        }
    }
}
