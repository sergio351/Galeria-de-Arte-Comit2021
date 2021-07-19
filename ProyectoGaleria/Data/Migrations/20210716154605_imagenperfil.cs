using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGaleria.Data.Migrations
{
    public partial class imagenperfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImgPerfil",
                table: "Artista",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPerfil",
                table: "Artista");
        }
    }
}
