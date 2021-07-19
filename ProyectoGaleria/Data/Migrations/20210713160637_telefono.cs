using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGaleria.Data.Migrations
{
    public partial class telefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechacreacion",
                table: "Artista",
                newName: "Fechacreacion");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Artista",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Artista");

            migrationBuilder.RenameColumn(
                name: "Fechacreacion",
                table: "Artista",
                newName: "fechacreacion");
        }
    }
}
