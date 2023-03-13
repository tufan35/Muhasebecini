using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muhasebecini.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accountant_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountant_Info", x => x.Id);
                },
                comment: "Muhasebeci Bilgileri");

            migrationBuilder.CreateTable(
                name: "Customer_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Info", x => x.Id);
                },
                comment: "Müşteri Bilgileri");

            migrationBuilder.CreateTable(
                name: "Commend_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commend_Info", x => x.Id);
                    table.ForeignKey(
                        name: "Accountant_Id_Fkey",
                        column: x => x.AccountantId,
                        principalTable: "Accountant_Info",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Customer_Id_Fkey",
                        column: x => x.CustomerId,
                        principalTable: "Customer_Info",
                        principalColumn: "Id");
                },
                comment: "Yorum Bilgileri");

            migrationBuilder.CreateIndex(
                name: "IX_Commend_Info_AccountantId",
                table: "Commend_Info",
                column: "AccountantId");

            migrationBuilder.CreateIndex(
                name: "IX_Commend_Info_CustomerId",
                table: "Commend_Info",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commend_Info");

            migrationBuilder.DropTable(
                name: "Accountant_Info");

            migrationBuilder.DropTable(
                name: "Customer_Info");
        }
    }
}
