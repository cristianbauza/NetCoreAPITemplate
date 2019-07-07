﻿// <auto-generated />
using System;
using DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190704015421_DocumentoPDFString")]
    partial class DocumentoPDFString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccesLayer.Models.Cliente", b =>
                {
                    b.Property<long>("Id_Cliente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Consultas", b =>
                {
                    b.Property<long>("Id_Consulta")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Consulta")
                        .HasMaxLength(2147483647);

                    b.Property<bool>("ConsultaVista");

                    b.Property<DateTime>("FechaHora");

                    b.Property<string>("Respuesta")
                        .HasMaxLength(2147483647);

                    b.Property<bool>("RespuestaVista");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Usuario");

                    b.HasKey("Id_Consulta");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Noticias", b =>
                {
                    b.Property<long>("Id_Noticia")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activa");

                    b.Property<DateTime>("FechaHora");

                    b.Property<string>("Imagen")
                        .HasMaxLength(2147483647);

                    b.Property<string>("Texto")
                        .HasMaxLength(2147483647);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id_Noticia");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Personas", b =>
                {
                    b.Property<long>("Id_Persona")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documento")
                        .HasMaxLength(128);

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(128);

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(128);

                    b.Property<string>("TipoDocumento")
                        .HasMaxLength(128);

                    b.HasKey("Id_Persona");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Personas_Contactos", b =>
                {
                    b.Property<long>("Id_PerCont")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<long?>("PersonaId_Persona");

                    b.Property<long?>("TipoContactoId_PerContTipo");

                    b.HasKey("Id_PerCont");

                    b.HasIndex("PersonaId_Persona");

                    b.HasIndex("TipoContactoId_PerContTipo");

                    b.ToTable("Personas_Contactos");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Personas_Contactos_Tipos", b =>
                {
                    b.Property<long>("Id_PerContTipo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("RegExp")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id_PerContTipo");

                    b.ToTable("Personas_Contactos_Tipos");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Seguros", b =>
                {
                    b.Property<long>("Id_DeSeguro")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ClienteId_Cliente");

                    b.Property<decimal>("CostoTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Descripccion")
                        .HasMaxLength(2048);

                    b.Property<string>("DocumentoPDF")
                        .HasMaxLength(2147483647);

                    b.Property<DateTime>("FechaFechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<long?>("TipoId_TipoDeSeguro");

                    b.Property<string>("Titulo")
                        .HasMaxLength(128);

                    b.HasKey("Id_DeSeguro");

                    b.HasIndex("ClienteId_Cliente");

                    b.HasIndex("TipoId_TipoDeSeguro");

                    b.ToTable("Seguros");
                });

            modelBuilder.Entity("DataAccesLayer.Models.TipoDeSeguro", b =>
                {
                    b.Property<long>("Id_TipoDeSeguro")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id_TipoDeSeguro");

                    b.ToTable("TiposDeSeguros");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Personas_Contactos", b =>
                {
                    b.HasOne("DataAccesLayer.Models.Personas", "Persona")
                        .WithMany("Personas_Contactos")
                        .HasForeignKey("PersonaId_Persona");

                    b.HasOne("DataAccesLayer.Models.Personas_Contactos_Tipos", "TipoContacto")
                        .WithMany()
                        .HasForeignKey("TipoContactoId_PerContTipo");
                });

            modelBuilder.Entity("DataAccesLayer.Models.Seguros", b =>
                {
                    b.HasOne("DataAccesLayer.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId_Cliente");

                    b.HasOne("DataAccesLayer.Models.TipoDeSeguro", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId_TipoDeSeguro");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
