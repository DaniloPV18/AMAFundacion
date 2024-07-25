using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correccionbrigada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 39, 981, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 25, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 22, 48, 40, 30, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 7, 15, 22, 48, 40, 54, DateTimeKind.Local).AddTicks(4913), "de5b5624-165f-4fcf-9c77-fe46c7792962" });

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_Name",
                table: "Brigades",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Brigades_Name",
                table: "Brigades");

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 398, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 0, 21, 38, 402, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 6, 23, 0, 21, 38, 404, DateTimeKind.Local).AddTicks(3513), "809dd305-a6ff-4581-8d57-1739e00c0894" });
        }
    }
}
