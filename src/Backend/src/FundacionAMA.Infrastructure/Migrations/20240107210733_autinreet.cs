using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class autinreet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "IdentificationType",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 7, 16, 7, 33, 640, DateTimeKind.Local).AddTicks(7057), "hx7w741jRKptsZJYyBjLQfz4agjKMGEJoK0kVwbbthI=", "50f352be-5172-438b-857d-f51c7895f67c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "IdentificationType",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "TempCode" },
                values: new object[] { new DateTime(2024, 1, 5, 23, 21, 39, 808, DateTimeKind.Local).AddTicks(4575), "H7eDfmsXbdEtTXH+1bIUi2SCp4nKUAgPkD5PsOtCxSM=", "8d18cb7e-72d0-4a38-bc37-03d7b0bf0a5a" });
        }
    }
}
