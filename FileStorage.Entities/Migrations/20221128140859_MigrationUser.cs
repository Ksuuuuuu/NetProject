using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileStorage.Entities.Migrations
{
    public partial class MigrationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "users",
                newName: "ModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "users",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "files",
                newName: "ModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "files",
                newName: "CreationTime");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "ModificationTime",
                table: "users",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "users",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "ModificationTime",
                table: "files",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "files",
                newName: "CreatedTime");
        }
    }
}
