using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMBD_App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 17, 44, 57, 499, DateTimeKind.Local).AddTicks(1537));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 17, 39, 14, 369, DateTimeKind.Local).AddTicks(2732));
        }
    }
}
