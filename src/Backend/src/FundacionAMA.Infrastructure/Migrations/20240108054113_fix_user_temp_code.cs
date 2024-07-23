using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_user_temp_code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TempCode",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 8, 0, 41, 13, 394, DateTimeKind.Local).AddTicks(4819), "94632a0d-9802-46d9-a775-f070510596cd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "TempCode",
                keyValue: null,
                column: "TempCode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TempCode",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 7, 16, 7, 33, 640, DateTimeKind.Local).AddTicks(7057), "50f352be-5172-438b-857d-f51c7895f67c" });
        }
    }
}
