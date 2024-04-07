using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impar.Infra.Migrations
{
    public partial class ChangeBaseMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "base64",
                table: "photos",
                type: "nvarchar(max)",
                maxLength: 2000000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "base64",
                table: "photos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2000000,
                oldNullable: true);
        }
    }
}
