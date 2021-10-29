using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAppAiudo.Migrations
{
    public partial class FirstMigratointoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    TransferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleForThisId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Interest = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
