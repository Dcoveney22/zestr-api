using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZestrApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleRecordJsonConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemSales",
                table: "SaleRecords",
                type: "text",
                nullable: false,
                oldClrType: typeof(Dictionary<string, int>),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Dictionary<string, int>>(
                name: "ItemSales",
                table: "SaleRecords",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
