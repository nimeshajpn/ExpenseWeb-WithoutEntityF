using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseWeb.Migrations
{
    public partial class addTbToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbExpensies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbExpensies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TbExpensies",
                columns: new[] { "Id", "Amount", "Category", "Date", "Type" },
                values: new object[] { 1, 1000.0, "Food", new DateTime(2022, 7, 19, 20, 59, 48, 251, DateTimeKind.Local).AddTicks(9718), "Expense" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbExpensies");
        }
    }
}
