using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net8AuthPractice1.Migrations
{
    /// <inheritdoc />
    public partial class AddloginDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$zKePx/QeG0OsoH1U0T9.1OtCwOh8g9hqXz1ICa9vpYRIqXcHWpOdW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xRK1jLJ0Zz32Z5fa9NQbwe70IkPE9r2Bf8WMhUb2dlqrdKmjYjm36");
        }
    }
}
