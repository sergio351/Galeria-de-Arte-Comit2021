using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGaleria.Data.Migrations
{
    public partial class actualizadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Artista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Artista",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
