using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class VacunasDbContext : DbContext
    {
        public VacunasDbContext()
        {
        }

        public VacunasDbContext(DbContextOptions<VacunasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdministrativoSalud> AdministrativoSalud { get; set; } = null!;
        public virtual DbSet<CentroVacunacion> CentroVacunacion { get; set; } = null!;
        public virtual DbSet<Enfermero> Enfermero { get; set; } = null!;
        public virtual DbSet<Paciente> Paciente { get; set; } = null!;
        public virtual DbSet<PersonalRegistro> PersonalRegistro { get; set; } = null!;
        public virtual DbSet<RegistroReporteIncidente> RegistroReporteIncidente { get; set; } = null!;
        public virtual DbSet<RegistroVacunacion> RegistroVacunacion { get; set; } = null!;
        public virtual DbSet<Vacuna> Vacuna { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-E0PCCEQB;Database=VacunasDb;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativoSalud>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos).HasMaxLength(30);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Distrito).HasMaxLength(20);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Genero).HasMaxLength(20);

                entity.Property(e => e.Nombres).HasMaxLength(30);

                entity.Property(e => e.Numero).HasMaxLength(20);
            });

            modelBuilder.Entity<CentroVacunacion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Distrito).HasMaxLength(20);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Enfermero>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos).HasMaxLength(30);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Distrito).HasMaxLength(20);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Genero).HasMaxLength(20);

                entity.Property(e => e.Nombres).HasMaxLength(30);

                entity.Property(e => e.Numero).HasMaxLength(20);

                entity.HasOne(d => d.CentroVacunacion)
                    .WithMany(p => p.Enfermero)
                    .HasForeignKey(d => d.CentroVacunacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enfermero_CentroVacunacion");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos).HasMaxLength(30);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Distrito).HasMaxLength(20);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FechaEmisionDni)
                    .HasColumnType("date")
                    .HasColumnName("FechaEmisionDNI");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Genero).HasMaxLength(20);

                entity.Property(e => e.Nombres).HasMaxLength(30);

                entity.Property(e => e.Numero).HasMaxLength(20);

                entity.HasOne(d => d.PersonalRegistro)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PersonalRegistroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_PersonalRegistro");
            });

            modelBuilder.Entity<PersonalRegistro>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos).HasMaxLength(30);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Distrito).HasMaxLength(20);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Genero).HasMaxLength(20);

                entity.Property(e => e.Nombres).HasMaxLength(30);

                entity.Property(e => e.Numero).HasMaxLength(20);
            });

            modelBuilder.Entity<RegistroReporteIncidente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.FechaReporte).HasColumnType("datetime");

                entity.Property(e => e.NivelImportancia).HasMaxLength(20);

                entity.HasOne(d => d.AdministrativoSalud)
                    .WithMany(p => p.RegistroReporteIncidente)
                    .HasForeignKey(d => d.AdministrativoSaludId)
                    .HasConstraintName("FK_RegistroReporteIncidente_AdministrativoSalud");

                entity.HasOne(d => d.CentroVacunacion)
                    .WithMany(p => p.RegistroReporteIncidente)
                    .HasForeignKey(d => d.CentroVacunacionId)
                    .HasConstraintName("FK_RegistroReporteIncidente_CentroVacunacion");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.RegistroReporteIncidente)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK_RegistroReporteIncidente_Paciente");
            });

            modelBuilder.Entity<RegistroVacunacion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaVacunacion).HasColumnType("datetime");

                entity.HasOne(d => d.CentroVacunacion)
                    .WithMany(p => p.RegistroVacunacion)
                    .HasForeignKey(d => d.CentroVacunacionId)
                    .HasConstraintName("FK_RegistroVacunacion_CentroVacunacion");

                entity.HasOne(d => d.Enfermero)
                    .WithMany(p => p.RegistroVacunacion)
                    .HasForeignKey(d => d.EnfermeroId)
                    .HasConstraintName("FK_RegistroVacunacion_Enfermero");

                entity.HasOne(d => d.PersonalRegistro)
                    .WithMany(p => p.RegistroVacunacion)
                    .HasForeignKey(d => d.PersonalRegistroId)
                    .HasConstraintName("FK_RegistroVacunacion_PersonalRegistro");

                entity.HasOne(d => d.Vacuna)
                    .WithMany(p => p.RegistroVacunacion)
                    .HasForeignKey(d => d.VacunaId)
                    .HasConstraintName("FK_RegistroVacunacion_Vacuna");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Laboratorio).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(20);

                entity.Property(e => e.Procedencia).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
