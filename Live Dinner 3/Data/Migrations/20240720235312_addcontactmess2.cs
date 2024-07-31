using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Live_Dinner_3.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcontactmess2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "contactMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "contactMessages");
        }
    }
}
