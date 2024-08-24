using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net8AuthPractice1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$JoR1QN/J5M1SfV6P31rShOAuS5GuJRSAW2uh3qIapNA.G4wkrGXAy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$uJpJuUFwEW786GSTdqmKv.EvjJjXuz2mU94J6/Oj/nRs6Zr08Leri");
        }
    }
}
