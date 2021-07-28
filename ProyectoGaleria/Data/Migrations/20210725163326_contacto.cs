using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGaleria.Data.Migrations
{
    public partial class contacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mensaje",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensaje",
                table: "Contacto");
        }
    }
}
