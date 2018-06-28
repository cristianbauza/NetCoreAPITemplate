using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccesLayer.Migrations
{
    public partial class Create_Tabla_Personas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Documento = table.Column<string>(maxLength: 128, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    PrimerApellido = table.Column<string>(maxLength: 128, nullable: false),
                    PrimerNombre = table.Column<string>(maxLength: 128, nullable: false),
                    SegundoApellido = table.Column<string>(maxLength: 128, nullable: true),
                    SegundoNombre = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
