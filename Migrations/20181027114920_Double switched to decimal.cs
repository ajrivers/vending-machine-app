using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachineApp.Migrations
{
    public partial class Doubleswitchedtodecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "CoinBudgets",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "CoinBudgets",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
