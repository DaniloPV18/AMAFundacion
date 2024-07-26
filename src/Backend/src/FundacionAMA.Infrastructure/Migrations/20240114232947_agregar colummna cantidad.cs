using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class agregarcolummnacantidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 18, 29, 47, 586, DateTimeKind.Local).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 14, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(7536), "93853529-7e89-4411-a819-29a5b15636c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Donations");

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 17, 39, 55, 767, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 14, 17, 39, 55, 770, DateTimeKind.Local).AddTicks(7220), "a996abb7-c964-481a-9ec8-e3df8d3fc688" });
        }
    }
}
