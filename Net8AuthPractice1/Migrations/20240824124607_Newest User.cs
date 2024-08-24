using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net8AuthPractice1.Migrations
{
    /// <inheritdoc />
    public partial class NewestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xRK1jLJ0Zz32Z5fa9NQbwe70IkPE9r2Bf8WMhUb2dlqrdKmjYjm36");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$QYwwccCbVfaI63c84H2iGOH5bc6ca0.0i/4enTv1EGB5E.GNUnocC");
        }
    }
}
