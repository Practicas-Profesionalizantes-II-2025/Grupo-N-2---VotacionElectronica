﻿// <auto-generated />
using System;
using Datos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(VotacionContext))]
    [Migration("20240821222616_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("en_US.UTF-8")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared.Entities.Candidatos", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidato"));

                    b.Property<string>("ApellidoCandidato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLista")
                        .HasColumnType("int");

                    b.Property<string>("NombreCandidato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PuestoCandidato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCandidato")
                        .HasName("PK_ID_CANDIDATO");

                    b.HasIndex("IdLista");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("Shared.Entities.Eleccion", b =>
                {
                    b.Property<int>("IdEleccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEleccion"));

                    b.Property<string>("DescripcionEleccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoEleccion")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFinEleccion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioEleccion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEleccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEleccion")
                        .HasName("PK_ID_ELECCION");

                    b.ToTable("Eleccion");
                });

            modelBuilder.Entity("Shared.Entities.EleccionLista", b =>
                {
                    b.Property<int>("IdEleccionLista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEleccionLista"));

                    b.Property<string>("DescripcionEleccionLista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEleccion")
                        .HasColumnType("int");

                    b.Property<int>("IdLista")
                        .HasColumnType("int");

                    b.HasKey("IdEleccionLista")
                        .HasName("PK_ID_ELECCIONLISTA");

                    b.HasIndex("IdEleccion");

                    b.HasIndex("IdLista");

                    b.ToTable("EleccionLista");
                });

            modelBuilder.Entity("Shared.Entities.Lista", b =>
                {
                    b.Property<int>("IdLista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLista"));

                    b.Property<int>("CantidadIntegrantes")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionLista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreLista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLista")
                        .HasName("PK_ID_LISTA");

                    b.ToTable("Lista");
                });

            modelBuilder.Entity("Shared.Entities.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("ApellidoPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContraseñaPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombrePersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona")
                        .HasName("PK_ID_PERSONA");

                    b.HasIndex("IdRol");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Shared.Entities.Resultado", b =>
                {
                    b.Property<int>("IdResultado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResultado"));

                    b.Property<int>("CantidadVotos")
                        .HasColumnType("int");

                    b.HasKey("IdResultado")
                        .HasName("PK_ID_RESULTADO");

                    b.ToTable("Resultado");
                });

            modelBuilder.Entity("Shared.Entities.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("DescripcionRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol")
                        .HasName("PK_ID_ROL");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Shared.Entities.Votante", b =>
                {
                    b.Property<int>("IdVotante")
                        .HasColumnType("int");

                    b.Property<bool>("EstadoVotacion")
                        .HasColumnType("bit");

                    b.Property<int?>("IdPersona")
                        .HasColumnType("int");

                    b.HasKey("IdVotante")
                        .HasName("PK_ID_VOTANTE");

                    b.HasIndex("IdPersona")
                        .IsUnique()
                        .HasFilter("[IdPersona] IS NOT NULL");

                    b.ToTable("Votante");
                });

            modelBuilder.Entity("Shared.Entities.Voto", b =>
                {
                    b.Property<int>("IdVoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVoto"));

                    b.Property<DateTime>("FechaVoto")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraVoto")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEleccion")
                        .HasColumnType("int");

                    b.Property<int>("IdLista")
                        .HasColumnType("int");

                    b.Property<int>("IdResultado")
                        .HasColumnType("int");

                    b.HasKey("IdVoto")
                        .HasName("PK_ID_VOTO");

                    b.HasIndex("IdEleccion");

                    b.HasIndex("IdLista");

                    b.HasIndex("IdResultado");

                    b.ToTable("Voto");
                });

            modelBuilder.Entity("Shared.Entities.Candidatos", b =>
                {
                    b.HasOne("Shared.Entities.Lista", "Lista")
                        .WithMany("Candidatos")
                        .HasForeignKey("IdLista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lista");
                });

            modelBuilder.Entity("Shared.Entities.EleccionLista", b =>
                {
                    b.HasOne("Shared.Entities.Eleccion", null)
                        .WithMany()
                        .HasForeignKey("IdEleccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Lista", null)
                        .WithMany()
                        .HasForeignKey("IdLista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Entities.Persona", b =>
                {
                    b.HasOne("Shared.Entities.Rol", "rol")
                        .WithMany("Personas")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rol");
                });

            modelBuilder.Entity("Shared.Entities.Votante", b =>
                {
                    b.HasOne("Shared.Entities.Persona", "Persona")
                        .WithOne("Votante")
                        .HasForeignKey("Shared.Entities.Votante", "IdPersona");

                    b.HasOne("Shared.Entities.Voto", "Voto")
                        .WithOne("Votante")
                        .HasForeignKey("Shared.Entities.Votante", "IdVotante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Voto");
                });

            modelBuilder.Entity("Shared.Entities.Voto", b =>
                {
                    b.HasOne("Shared.Entities.Eleccion", "Eleccion")
                        .WithMany("Votos")
                        .HasForeignKey("IdEleccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Lista", "Lista")
                        .WithMany("Votos")
                        .HasForeignKey("IdLista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Resultado", "Resultado")
                        .WithMany("Votos")
                        .HasForeignKey("IdResultado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eleccion");

                    b.Navigation("Lista");

                    b.Navigation("Resultado");
                });

            modelBuilder.Entity("Shared.Entities.Eleccion", b =>
                {
                    b.Navigation("Votos");
                });

            modelBuilder.Entity("Shared.Entities.Lista", b =>
                {
                    b.Navigation("Candidatos");

                    b.Navigation("Votos");
                });

            modelBuilder.Entity("Shared.Entities.Persona", b =>
                {
                    b.Navigation("Votante");
                });

            modelBuilder.Entity("Shared.Entities.Resultado", b =>
                {
                    b.Navigation("Votos");
                });

            modelBuilder.Entity("Shared.Entities.Rol", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Shared.Entities.Voto", b =>
                {
                    b.Navigation("Votante")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
