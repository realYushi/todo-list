using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitalSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Role", "Status", "Username" },
                values: new object[] { "user1", "john.doe@example.com", "Admin", "Active", "johndoe" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { "list1", "Tasks to do at home.", "Home Tasks", "user1" },
                    { "list2", "Tasks to do at work.", "Work Tasks", "user1" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "DueDate", "ListId", "Status", "Title" },
                values: new object[,]
                {
                    { "task1", "Wash all the dishes from dinner.", new DateTime(2024, 7, 4, 22, 25, 49, 643, DateTimeKind.Local).AddTicks(5220), "list1", 1, "Wash dishes" },
                    { "task2", "Prepare the monthly performance presentation.", new DateTime(2024, 7, 6, 22, 25, 49, 643, DateTimeKind.Local).AddTicks(5260), "list2", 2, "Prepare presentation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task1");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "task2");

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: "list1");

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: "list2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user1");
        }
    }
}
