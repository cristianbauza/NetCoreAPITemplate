using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccesLayer.Migrations
{
    public partial class FKContactos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
