using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cabiotiponticacin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                columns: new[] { "Active", "CreatedAt" },
                values: new object[] { true, new DateTime(2024, 1, 8, 20, 16, 59, 856, DateTimeKind.Local).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 16, 59, 860, DateTimeKind.Local).AddTicks(1489), "42d3d2e2-4351-4e61-ac9f-a99974993645" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentificationType",
                keyColumn: "Id",
                keyValue: (short)1,
                columns: new[] { "Active", "CreatedAt" },
                values: new object[] { false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 7, 16, 7, 33, 640, DateTimeKind.Local).AddTicks(7057), "50f352be-5172-438b-857d-f51c7895f67c" });
        }
    }
}
