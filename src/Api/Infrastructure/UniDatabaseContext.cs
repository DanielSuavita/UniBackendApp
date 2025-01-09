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

    public virtual DbSet<AsignaturasEstudiante> AsignaturasEstudiantes { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<EstadoMatricula> EstadoMatriculas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.ToTable("Asignatura");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AsignaturasEstudiante>(entity =>
        {
            entity.ToTable("AsignaturasEstudiante");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.AsignaturasEstudiantes)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignatura_TO_AsignaturasEstudiante");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.AsignaturasEstudiantes)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadoMatricula_TO_AsignaturasEstudiante");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.AsignaturasEstudianteIdEstudianteNavigations)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_AsignaturasEstudiante");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.AsignaturasEstudianteIdProfesorNavigations)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_AsignaturasEstudiante1");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TO_Creditos");
        });

        modelBuilder.Entity<EstadoMatricula>(entity =>
        {
            entity.ToTable("EstadoMatricula");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Rol1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.ToTable("UsuarioRol");

            entity.Property(e => e.Id).ValueGeneratedNever();

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
