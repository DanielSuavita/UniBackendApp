using System;
using System.Collections.Generic;
using Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure;

public partial class UniDatabaseContext : DbContext
{
    public UniDatabaseContext()
    {
    }

    public UniDatabaseContext(DbContextOptions<UniDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<AsignaturasMatricula> AsignaturasMatriculas { get; set; }

    public virtual DbSet<AsignaturasProfesor> AsignaturasProfesors { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<PeriodoAcademico> PeriodoAcademicos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.ToTable("Asignatura");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AsignaturasMatricula>(entity =>
        {
            entity.ToTable("AsignaturasMatricula");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.AsignaturasMatriculas)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignatura_TO_AsignaturasMatricula");

            entity.HasOne(d => d.IdMatriculaNavigation).WithMany(p => p.AsignaturasMatriculas)
                .HasForeignKey(d => d.IdMatricula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matricula_TO_AsignaturasMatricula");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.AsignaturasMatriculas)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_AsignaturasMatricula");
        });

        modelBuilder.Entity<AsignaturasProfesor>(entity =>
        {
            entity.ToTable("AsignaturasProfesor");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.AsignaturasProfesors)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignatura_TO_AsignaturasProfesor");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.AsignaturasProfesors)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_AsignaturasProfesor");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_Creditos");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.ToTable("Matricula");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_Matricula");

            entity.HasOne(d => d.IdPeriodoAcademicoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdPeriodoAcademico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoAcademico_TO_Matricula");
        });

        modelBuilder.Entity<PeriodoAcademico>(entity =>
        {
            entity.ToTable("PeriodoAcademico");

            entity.Property(e => e.Periodo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.Property(e => e.Rol1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.ToTable("UsuarioRol");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_TO_UsuarioRol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_UsuarioRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
