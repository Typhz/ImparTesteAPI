using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impar.Infra.Migrations
{
    public partial class RemoveStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
