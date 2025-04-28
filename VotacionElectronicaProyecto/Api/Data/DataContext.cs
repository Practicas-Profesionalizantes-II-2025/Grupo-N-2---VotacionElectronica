using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Api.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Eleccion> Eleccion { get; set; }
        public virtual DbSet<Lista> Lista { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Resultado> Resultado { get; set; }
        public virtual DbSet<Voto> Voto { get; set; }
        public virtual DbSet<EleccionLista> EleccionListas { get; set; }
        public virtual DbSet<PersonaEleccion> PersonaElecciones{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            //modelBuilder.Entity<Candidatos>(entity =>
            //{
            //    entity.HasKey(e => e.Id)
            //        .HasName("PK_ID_CANDIDATO");
            //    entity.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
            //});
            modelBuilder.Entity<Candidatos>().Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Eleccion>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_ELECCION");
                entity.Property(x => x.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");
                
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
                entity.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
                entity.HasMany(e => e.Candidatos)
                .WithOne(e => e.Lista)
                .HasForeignKey("IdLista")
                .IsRequired();

            });
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_PERSONA");
                entity.Property(x => x.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");

            });
            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_RESULTADO");


            });

            modelBuilder.Entity<Voto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ID_VOTO");

                entity.HasOne(v => v.Eleccion)
                    .WithMany(e => e.Votos)
                    .HasForeignKey(v => v.EleccionId)
                    .OnDelete(DeleteBehavior.Restrict); // Cambiar a Restrict o NoAction

                
                entity.HasOne(v => v.Resultado)
                    .WithMany(r => r.Votos)
                    .HasForeignKey(v => v.ResultadoId)
                    .OnDelete(DeleteBehavior.NoAction); // Cambiar a NoAction para evitar cascadas
            });

            modelBuilder.Entity<PersonaEleccion>()
        .HasKey(pe => new { pe.PersonaId, pe.EleccionId });

            modelBuilder.Entity<PersonaEleccion>()
                .HasOne(pe => pe.Persona)
                .WithMany(p => p.PersonaElecciones)
                .HasForeignKey(pe => pe.PersonaId);

            modelBuilder.Entity<PersonaEleccion>()
                .HasOne(pe => pe.Eleccion)
                .WithMany(e => e.PersonaElecciones)
                .HasForeignKey(pe => pe.EleccionId);



            // Configura la relación con Resultado
            modelBuilder.Entity<EleccionLista>()
                    .HasOne(e => e.Eleccion)
                    .WithMany()
                    .HasForeignKey(e => e.IdEleccion)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EleccionLista>()
                    .HasOne(e => e.Lista)
                    .WithMany()
                    .HasForeignKey(e => e.IdLista)
                    .OnDelete(DeleteBehavior.NoAction);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.DoCustomEntityPreparations();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            this.DoCustomEntityPreparations();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void DoCustomEntityPreparations()
        {
            // Cuando el estado de la entidad es Modified, en ese momento le asigno la fecha de la actualizacion
            var modifiedEntitiesWithTrackDate = this
                .ChangeTracker.Entries()
                .Where(c => c.State == EntityState.Modified);
            foreach (var entityEntry in modifiedEntitiesWithTrackDate)
            {
                if (entityEntry.Properties.Any(c => c.Metadata.Name == "UpdatedDate"))
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder
                .Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
