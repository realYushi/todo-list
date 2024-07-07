using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateSeeding4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "user1",
                column: "Password",
                value: "$2a$12$0VFPWv7NCbT.btA5UC4DneDr50tn6ge4.jslK/DABt3/JMX.1QAx.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "user2",
                column: "Password",
                value: "$2a$12$0VFPWv7NCbT.btA5UC4DneDr50tn6ge4.jslK/DABt3/JMX.1QAx.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "user1",
                column: "Password",
                value: "password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "user2",
                column: "Password",
                value: "password");
        }
    }
}
