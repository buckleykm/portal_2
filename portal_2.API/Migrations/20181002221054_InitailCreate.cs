using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portal_2.API.Migrations
{
    public partial class InitailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrokerTempId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Fstname = table.Column<string>(nullable: true),
                    Lstname = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    Rbm = table.Column<string>(nullable: true),
                    Affiliate = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    AltEmail = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    PhoneExt = table.Column<int>(nullable: false),
                    AltPhone = table.Column<string>(nullable: true),
                    IsContracted = table.Column<bool>(nullable: false),
                    NpnId = table.Column<int>(nullable: false),
                    ModifyWhen = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    PolNo = table.Column<string>(nullable: true),
                    Apftnm = table.Column<string>(nullable: true),
                    Apltnm = table.Column<string>(nullable: true),
                    Submittd = table.Column<DateTime>(nullable: true),
                    Placed = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    BrokerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
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

            migrationBuilder.DropTable(
                name: "Brokers");
        }
    }
}
