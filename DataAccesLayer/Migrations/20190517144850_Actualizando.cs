using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class Actualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Contactos_Personas_Id_Persona",
                table: "Personas_Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Contactos_Id_Persona",
                table: "Personas_Contactos");

            migrationBuilder.DropColumn(
                name: "Id_Persona",
                table: "Personas_Contactos");

            migrationBuilder.AddColumn<long>(
                name: "PersonaId_Persona",
                table: "Personas_Contactos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoContactoId_PerContTipo",
                table: "Personas_Contactos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Personas_Contactos_Tipos",
                columns: table => new
                {
                    Id_PerContTipo = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 128, nullable: false),
                    RegExp = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas_Contactos_Tipos", x => x.Id_PerContTipo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Contactos_PersonaId_Persona",
                table: "Personas_Contactos",
                column: "PersonaId_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Contactos_TipoContactoId_PerContTipo",
                table: "Personas_Contactos",
                column: "TipoContactoId_PerContTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Contactos_Personas_PersonaId_Persona",
                table: "Personas_Contactos",
                column: "PersonaId_Persona",
                principalTable: "Personas",
                principalColumn: "Id_Persona",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Contactos_Personas_Contactos_Tipos_TipoContactoId_P~",
                table: "Personas_Contactos",
                column: "TipoContactoId_PerContTipo",
                principalTable: "Personas_Contactos_Tipos",
                principalColumn: "Id_PerContTipo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Contactos_Personas_PersonaId_Persona",
                table: "Personas_Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Contactos_Personas_Contactos_Tipos_TipoContactoId_P~",
                table: "Personas_Contactos");

            migrationBuilder.DropTable(
                name: "Personas_Contactos_Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Contactos_PersonaId_Persona",
                table: "Personas_Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Contactos_TipoContactoId_PerContTipo",
                table: "Personas_Contactos");

            migrationBuilder.DropColumn(
                name: "PersonaId_Persona",
                table: "Personas_Contactos");

            migrationBuilder.DropColumn(
                name: "TipoContactoId_PerContTipo",
                table: "Personas_Contactos");

            migrationBuilder.AddColumn<long>(
                name: "Id_Persona",
                table: "Personas_Contactos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Contactos_Id_Persona",
                table: "Personas_Contactos",
                column: "Id_Persona");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Contactos_Personas_Id_Persona",
                table: "Personas_Contactos",
                column: "Id_Persona",
                principalTable: "Personas",
                principalColumn: "Id_Persona",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
