using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impar.Infra.Migrations
{
    public partial class ChangeRelationshipsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "photos",
                newName: "car_id");

            migrationBuilder.RenameIndex(
                name: "IX_photos_CarId",
                table: "photos",
                newName: "IX_photos_car_id");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "cars",
                newName: "photo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "car_id",
                table: "photos",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_photos_car_id",
                table: "photos",
                newName: "IX_photos_CarId");

            migrationBuilder.RenameColumn(
                name: "photo_id",
                table: "cars",
                newName: "PhotoId");
        }
    }
}
