using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class agregardonacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Volunteer",
                table: "Persons",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Donor",
                table: "Persons",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DonationType",
                type: "char(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldFixedLength: true,
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DonationType",
                columns: new[] { "Id", "Active", "CompanyId", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1488), 0, "viveres", "A", null, null },
                    { 2, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1500), 0, "medicina", "A", null, null },
                    { 3, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1502), 0, "vestimenta", "A", null, null },
                    { 4, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1503), 0, "monetario", "A", null, null },
                    { 5, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1505), 0, "tecnologia", "A", null, null },
                    { 6, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1506), 0, "suministros", "A", null, null },
                    { 7, true, null, new DateTime(2024, 1, 14, 17, 39, 55, 766, DateTimeKind.Local).AddTicks(1508), 0, "varios", "A", null, null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<bool>(
                name: "Volunteer",
                table: "Persons",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "Donor",
                table: "Persons",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DonationType",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(30)",
                oldFixedLength: true,
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 9, 23, 1, 3, 298, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 8, 0, 41, 13, 394, DateTimeKind.Local).AddTicks(4819), "94632a0d-9802-46d9-a775-f070510596cd" });
        }
    }
}
