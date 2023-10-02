using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JguevaraNetCoreContext : DbContext
{
    public JguevaraNetCoreContext()
    {
    }

    public JguevaraNetCoreContext(DbContextOptions<JguevaraNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RecetaMedica> RecetaMedicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALIEN71; Database= JGuevaraNetCore; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B34D0FB32");

            entity.ToTable("Paciente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecetaMedica>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("PK__RecetaMe__2CEFF1575DB6DE6E");

            entity.ToTable("RecetaMedica");

            entity.Property(e => e.Diagnostico).HasColumnType("text");
            entity.Property(e => e.FechaConsulta).HasColumnType("date");
            entity.Property(e => e.NombreMedico)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.NotasAdicionales).HasColumnType("text");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.RecetaMedicas)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__RecetaMed__IdPac__1273C1CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
