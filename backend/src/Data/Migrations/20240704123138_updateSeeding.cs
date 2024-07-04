using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Role", "Status", "Username" },
                values: new object[] { "user2", "jane.doe@example.com", "User", "Active", "janedoe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user2");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task1",
                column: "DueDate",
                value: new DateTime(2024, 7, 4, 22, 25, 49, 643, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task2",
                column: "DueDate",
                value: new DateTime(2024, 7, 6, 22, 25, 49, 643, DateTimeKind.Local).AddTicks(5260));
        }
    }
}
