using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class Seguros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id_DeSeguro = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId_Cliente = table.Column<long>(nullable: true),
                    TipoId_TipoDeSeguro = table.Column<long>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFechaFin = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 128, nullable: true),
                    Descripccion = table.Column<string>(maxLength: 2048, nullable: true),
                    DocumentoPDF = table.Column<byte[]>(maxLength: 2147483647, nullable: true),
                    CostoTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id_DeSeguro);
                    table.ForeignKey(
                        name: "FK_Seguros_Clientes_ClienteId_Cliente",
                        column: x => x.ClienteId_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seguros_TiposDeSeguros_TipoId_TipoDeSeguro",
                        column: x => x.TipoId_TipoDeSeguro,
                        principalTable: "TiposDeSeguros",
                        principalColumn: "Id_TipoDeSeguro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_ClienteId_Cliente",
                table: "Seguros",
                column: "ClienteId_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_TipoId_TipoDeSeguro",
                table: "Seguros",
                column: "TipoId_TipoDeSeguro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguros");
        }
    }
}
