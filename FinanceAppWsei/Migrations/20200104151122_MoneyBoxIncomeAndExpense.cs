using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceAppWsei.Migrations
{
    public partial class MoneyBoxIncomeAndExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "MoneyBoxes");

            migrationBuilder.AddColumn<Guid>(
                name: "MoneyBoxId",
                table: "Incomes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MoneyBoxId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_MoneyBoxId",
                table: "Incomes",
                column: "MoneyBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_MoneyBoxId",
                table: "Expenses",
                column: "MoneyBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_MoneyBoxes_MoneyBoxId",
                table: "Expenses",
                column: "MoneyBoxId",
                principalTable: "MoneyBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_MoneyBoxes_MoneyBoxId",
                table: "Incomes",
                column: "MoneyBoxId",
                principalTable: "MoneyBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_MoneyBoxes_MoneyBoxId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_MoneyBoxes_MoneyBoxId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_MoneyBoxId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_MoneyBoxId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "MoneyBoxId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "MoneyBoxId",
                table: "Expenses");

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "MoneyBoxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
