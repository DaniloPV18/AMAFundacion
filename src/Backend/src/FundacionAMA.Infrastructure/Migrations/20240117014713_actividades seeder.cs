using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class actividadesseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActivityType",
                type: "char(60)",
                fixedLength: true,
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.InsertData(
            //    table: "ActivityType",
            //    columns: new[] { "Id", "Active", "CompanyId", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
            //    values: new object[] { 1, true, null, new DateTime(2024, 1, 16, 20, 47, 13, 561, DateTimeKind.Local).AddTicks(6950), 0, "PRUEBA DE ACTIVIDAD", "A", null, null });

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8749));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8765));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 3,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8766));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 4,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8770));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 5,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8771));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 6,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8772));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 7,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 565, DateTimeKind.Local).AddTicks(8776));

            //migrationBuilder.UpdateData(
            //    table: "IdentificationType",
            //    keyColumn: "Id",
            //    keyValue: (short)1,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 16, 20, 47, 13, 566, DateTimeKind.Local).AddTicks(7033));

            //migrationBuilder.UpdateData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "CreatedAt", "TempCode" },
            //    values: new object[] { new DateTime(2024, 1, 16, 20, 47, 13, 568, DateTimeKind.Local).AddTicks(3425), "f4d97b19-451b-4c1f-9254-9cb4d1cbc0cf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActivityType",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(60)",
                oldFixedLength: true,
                oldMaxLength: 60,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8167));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8180));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 3,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8182));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 4,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8183));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 5,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8185));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 6,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8187));

            //migrationBuilder.UpdateData(
            //    table: "DonationType",
            //    keyColumn: "Id",
            //    keyValue: 7,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 584, DateTimeKind.Local).AddTicks(8190));

            //migrationBuilder.UpdateData(
            //    table: "IdentificationType",
            //    keyColumn: "Id",
            //    keyValue: (short)1,
            //    column: "CreatedAt",
            //    value: new DateTime(2024, 1, 14, 18, 29, 47, 586, DateTimeKind.Local).AddTicks(5327));

            //migrationBuilder.UpdateData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "CreatedAt", "TempCode" },
            //    values: new object[] { new DateTime(2024, 1, 14, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(7536), "93853529-7e89-4411-a819-29a5b15636c5" });
        }
    }
}
