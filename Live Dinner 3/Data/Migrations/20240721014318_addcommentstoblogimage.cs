using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Live_Dinner_3.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcommentstoblogimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "blogs");
        }
    }
}
