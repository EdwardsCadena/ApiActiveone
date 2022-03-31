using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Activeone.Core.Entities;

namespace Activeone.Infrastructure.Data
{
    public partial class activeone1Context : DbContext
    {
        public activeone1Context()
        {
        }

        public activeone1Context(DbContextOptions<activeone1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquilers { get; set; } = null!;
        public virtual DbSet<Cd> Cds { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detallealquiler> Detallealquilers { get; set; } = null!;
        public virtual DbSet<Sancion> Sancions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.IdAlquiler)
                    .HasName("PK__Alquiler__CB9A46B78A314424");

                entity.ToTable("Alquiler");

                entity.Property(e => e.FechaAkquiler).HasColumnType("date");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("Fkcliente");
            });

            modelBuilder.Entity<Cd>(entity =>
            {
                entity.HasKey(e => e.IdCd)
                    .HasName("PK__cd__B77390A71B60AFF1");

                entity.ToTable("cd");

                entity.Property(e => e.Condicion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__D5946642DC679FE4");

                entity.ToTable("cliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fechainscripcion).HasColumnType("date");

                entity.Property(e => e.Fechanacimiento).HasColumnType("date");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroDni)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemaInteres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detallealquiler>(entity =>
            {
                entity.HasKey(e => e.IdDetallealquiler)
                    .HasName("PK__Detallea__E6E188C8AC0DCDE5");

                entity.ToTable("Detallealquiler");

                entity.Property(e => e.Fechadevolucion).HasColumnType("date");

                entity.HasOne(d => d.IdAlquilerdetalleNavigation)
                    .WithMany(p => p.Detallealquilers)
                    .HasForeignKey(d => d.IdAlquilerdetalle)
                    .HasConstraintName("FkAlquilerdetalle");

                entity.HasOne(d => d.IdCddetalleNavigation)
                    .WithMany(p => p.Detallealquilers)
                    .HasForeignKey(d => d.IdCddetalle)
                    .HasConstraintName("FkCddetalle");
            });

            modelBuilder.Entity<Sancion>(entity =>
            {
                entity.HasKey(e => e.Idsancion)
                    .HasName("PK__sancion__B5B48C20CB06471F");

                entity.ToTable("sancion");

                entity.Property(e => e.Tipodesancion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAlquilerSancionNavigation)
                    .WithMany(p => p.Sancions)
                    .HasForeignKey(d => d.IdAlquilerSancion)
                    .HasConstraintName("FkIdAlquilersancion");

                entity.HasOne(d => d.IdclienteSancionNavigation)
                    .WithMany(p => p.Sancions)
                    .HasForeignKey(d => d.IdclienteSancion)
                    .HasConstraintName("Fkclientesancion");
            });
        }

    }
}
