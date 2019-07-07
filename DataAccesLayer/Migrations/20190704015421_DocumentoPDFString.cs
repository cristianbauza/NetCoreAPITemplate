using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class DocumentoPDFString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentoPDF",
                table: "Seguros",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 2147483647,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "DocumentoPDF",
                table: "Seguros",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2147483647,
                oldNullable: true);
        }
    }
}
