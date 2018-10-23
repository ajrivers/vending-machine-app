using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachineApp.Migrations
{
    public partial class CoinsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "CoinBudgets",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "CoinBudgets",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
