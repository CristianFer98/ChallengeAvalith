using System;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ParkingModels.Data
{
    public partial class ParkingContext : DbContext
    {
        public ParkingContext()
        {
        }

        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autos> Autos { get; set; }
        public virtual DbSet<Parking> Parking { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AVALITH;Database=Parking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autos>(entity =>
            {
                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Patente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.DNI)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Autos>()
            .HasOne(a => a.Usuario)
            .WithMany()
            .HasForeignKey(a => a.IdUsuario);

            modelBuilder.Entity<Parking>()
                .HasOne(p => p.Auto)
                .WithMany()
                .HasForeignKey(p => p.IdAuto);

            modelBuilder.Entity<Parking>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
