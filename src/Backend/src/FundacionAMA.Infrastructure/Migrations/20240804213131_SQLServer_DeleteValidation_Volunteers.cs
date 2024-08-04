using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SQLServer_DeleteValidation_Volunteers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Volunteers",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Volunteers",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldUnicode: false,
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityTypeId",
                table: "Volunteers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Beneficiaries",
                type: "nchar(200)",
                fixedLength: true,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 684, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 688, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 4, 16, 31, 31, 689, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 8, 4, 16, 31, 31, 691, DateTimeKind.Local).AddTicks(2740), "52a9e02e-cc7e-41a0-8909-9887beef59aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Volunteers",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Volunteers",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldUnicode: false,
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityTypeId",
                table: "Volunteers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Beneficiaries",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(200)",
                oldFixedLength: true,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 901, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "DonationType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 906, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 0, 5, 53, 907, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 7, 26, 0, 5, 53, 909, DateTimeKind.Local).AddTicks(7817), "2028a12a-489b-46f1-8e0e-c889f3f83492" });
        }
    }
}
