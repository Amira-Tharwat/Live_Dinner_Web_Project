using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Live_Dinner_3.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcontactmess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_messages",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "messages");

            migrationBuilder.RenameTable(
                name: "messages",
                newName: "contactMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contactMessages",
                table: "contactMessages",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_contactMessages",
                table: "contactMessages");

            migrationBuilder.RenameTable(
                name: "contactMessages",
                newName: "messages");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_messages",
                table: "messages",
                column: "Id");
        }
    }
}
