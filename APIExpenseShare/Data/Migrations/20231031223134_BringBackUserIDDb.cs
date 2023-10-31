using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIExpenseShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class BringBackUserIDDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountDetailId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAccountDetailId",
                table: "Users");
        }
    }
}
