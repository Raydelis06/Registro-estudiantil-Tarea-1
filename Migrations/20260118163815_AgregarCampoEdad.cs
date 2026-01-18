using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_estudiantil___Tarea_1.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoEdad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Estudiantes");
        }
    }
}
