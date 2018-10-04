using Microsoft.EntityFrameworkCore.Migrations;

namespace portal_2.API.Migrations
{
    public partial class AddedBrokerIdToApps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Brokers_BrokerId",
                table: "Apps");

            migrationBuilder.AlterColumn<int>(
                name: "BrokerId",
                table: "Apps",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Brokers_BrokerId",
                table: "Apps",
                column: "BrokerId",
                principalTable: "Brokers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Brokers_BrokerId",
                table: "Apps");

            migrationBuilder.AlterColumn<int>(
                name: "BrokerId",
                table: "Apps",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Brokers_BrokerId",
                table: "Apps",
                column: "BrokerId",
                principalTable: "Brokers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
