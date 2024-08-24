using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net8AuthPractice1.Migrations
{
    /// <inheritdoc />
    public partial class NewUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$QYwwccCbVfaI63c84H2iGOH5bc6ca0.0i/4enTv1EGB5E.GNUnocC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$JoR1QN/J5M1SfV6P31rShOAuS5GuJRSAW2uh3qIapNA.G4wkrGXAy");
        }
    }
}
