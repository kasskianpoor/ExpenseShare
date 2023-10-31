using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIExpenseShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserRelatedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserAccountDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccountDetails",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserAccountDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "UserAccountDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountDetails_Email",
                table: "UserAccountDetails",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAccountDetails_Email",
                table: "UserAccountDetails");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserAccountDetails");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserAccountDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserName",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "UserAccountDetails",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "UserAccountDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
