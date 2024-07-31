using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Live_Dinner_3.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddateandtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_blogs_BlogId",
                table: "comment");

            migrationBuilder.AlterColumn<int>(
                name: "NumOfPersons",
                table: "reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_blogs_BlogId",
                table: "comment",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_blogs_BlogId",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "NumOfPersons",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_blogs_BlogId",
                table: "comment",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id");
        }
    }
}
