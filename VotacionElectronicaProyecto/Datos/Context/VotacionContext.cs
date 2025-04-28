using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Context
{
    public partial class VotacionContext : DbContext
    {
        public VotacionContext()
        {

        }

        public VotacionContext(DbContextOptions<VotacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Eleccion> Eleccion { get; set; }
        public virtual DbSet<Lista> Lista { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Resultado> Resultado { get; set; }
        public virtual DbSet<Votante> Votante { get; set; }
        public virtual DbSet<Voto> Voto { get; set; }
        public virtual DbSet<EleccionLista> EleccionListas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=VotacionProg2024;Integrated Security=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_CANDIDATO");                
            });
            modelBuilder.Entity<Eleccion>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_ELECCION");
                entity.HasMany(e => e.Votos)
                .WithOne(e => e.Eleccion)
                .HasForeignKey("IdEleccion")
                .IsRequired();
                entity.HasMany(e => e.Listas)
                .WithMany(e => e.Elecciones)
                .UsingEntity<EleccionLista>(
                    l => l.HasOne<Lista>().WithMany().HasForeignKey(e => e.IdLista),
                    a => a.HasOne<Eleccion>().WithMany().HasForeignKey(e => e.IdEleccion));

            });
            modelBuilder.Entity<Lista>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_LISTA");
                entity.HasMany(e => e.Votos)
                .WithOne(e => e.Lista)
                .HasForeignKey("IdLista")
                .IsRequired();
                entity.HasMany(e => e.Candidatos)
                .WithOne(e => e.Lista)
                .HasForeignKey("IdLista")
                .IsRequired();
                
            });
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.NroIdentificacionPersona)
                    .HasName("PK_ID_PERSONA");
                entity.HasOne(e => e.Votante)
                .WithOne(e => e.Persona)
                .HasForeignKey<Votante>("Id")
                .IsRequired(false);

            });
            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_RESULTADO");
                entity.HasMany(e => e.Votos)
                .WithOne(e => e.Resultado)
                .HasForeignKey("IdResultado")
                .IsRequired();
             
            });           
            modelBuilder.Entity<Votante>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_VOTANTE");
                entity.HasOne(e => e.Voto)
                .WithOne(e => e.Votante)
                .HasForeignKey<Votante>("IdVotante")
                .IsRequired();
            });
            modelBuilder.Entity<Voto>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_VOTO");
            });
            modelBuilder.Entity<EleccionLista>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_ELECCIONLISTA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


