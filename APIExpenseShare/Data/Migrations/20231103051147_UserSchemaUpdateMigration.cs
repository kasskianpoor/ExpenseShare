using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIExpenseShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserSchemaUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAccountDetailId",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountDetailId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }
    }
}
