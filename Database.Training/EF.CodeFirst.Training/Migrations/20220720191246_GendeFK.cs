using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.CodeFirst.Training.Migrations
{
    public partial class GendeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGender_Users_UserId",
                table: "UsersGender");

            migrationBuilder.DropIndex(
                name: "IX_UsersGender_UserId",
                table: "UsersGender");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersGender");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersGender_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "UsersGender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersGender_GenderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GenderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersGender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersGender_UserId",
                table: "UsersGender",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGender_Users_UserId",
                table: "UsersGender",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
