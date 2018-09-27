using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portal_2.API.Migrations
{
    public partial class ExtendedBrokerClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AffiliateId",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AltEmail",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltPhone",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fstname",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsContracted",
                table: "Brokers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Brokers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Lstname",
                table: "Brokers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyWhen",
                table: "Brokers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NpnId",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneExt",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RbmId",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Brokers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PolNo = table.Column<string>(nullable: true),
                    Apftnm = table.Column<string>(nullable: true),
                    Apltnm = table.Column<string>(nullable: true),
                    Submittd = table.Column<DateTime>(nullable: false),
                    Placed = table.Column<DateTime>(nullable: true),
                    BrokerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "BrokerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_BrokerId",
                table: "Apps",
                column: "BrokerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "AffiliateId",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "AltEmail",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "AltPhone",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "Fstname",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "IsContracted",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "Lstname",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "ModifyWhen",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "NpnId",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "PhoneExt",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "RbmId",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Brokers");
        }
    }
}
