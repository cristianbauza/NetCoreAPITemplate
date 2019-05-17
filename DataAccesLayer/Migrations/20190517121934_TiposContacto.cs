using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccesLayer.Migrations
{
    public partial class TiposContacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id_PerContTipo",
                table: "Personas_Contactos",
                nullable: false,
                defaultValue: 0L);

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
                name: "IX_Personas_Contactos_Id_PerContTipo",
                table: "Personas_Contactos",
                column: "Id_PerContTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Contactos_Personas_Contactos_Tipos_Id_PerContTipo",
                table: "Personas_Contactos",
                column: "Id_PerContTipo",
                principalTable: "Personas_Contactos_Tipos",
                principalColumn: "Id_PerContTipo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Contactos_Personas_Contactos_Tipos_Id_PerContTipo",
                table: "Personas_Contactos");

            migrationBuilder.DropTable(
                name: "Personas_Contactos_Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Contactos_Id_PerContTipo",
                table: "Personas_Contactos");

            migrationBuilder.DropColumn(
                name: "Id_PerContTipo",
                table: "Personas_Contactos");
        }
    }
}
