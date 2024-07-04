using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateSeeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task1",
                column: "DueDate",
                value: new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task2",
                column: "DueDate",
                value: new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task1",
                column: "DueDate",
                value: new DateTime(2024, 7, 6, 0, 31, 38, 374, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task2",
                column: "DueDate",
                value: new DateTime(2024, 7, 8, 0, 31, 38, 374, DateTimeKind.Local).AddTicks(8450));
        }
    }
}
