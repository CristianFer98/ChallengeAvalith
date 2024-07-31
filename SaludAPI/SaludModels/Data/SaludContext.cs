using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaludModels.Data
{
    public partial class SaludContext : DbContext
    {
        public SaludContext()
        {
        }

        public SaludContext(DbContextOptions<SaludContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CentroDeSalud> CentroDeSalud { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AVALITH;Database=Salud;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turnos>(entity =>
            {
                entity.Property(e => e.Horario)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDeTramite)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turnos>()
                .HasOne(p => p.IdCentroDeSaludNavigation)
                .WithMany()
                .HasForeignKey(p => p.IdCentroDeSalud);

            modelBuilder.Entity<Turnos>()
                .HasOne(p => p.IdEspecialidadNavigation)
                .WithMany()
                .HasForeignKey(p => p.IdEspecialidad);


            modelBuilder.Entity<Turnos>()
                .HasOne(p => p.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
