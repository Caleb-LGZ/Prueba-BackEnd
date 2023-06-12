using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_BackEnd.Models;

public partial class BdPruebaContext : DbContext
{
    public BdPruebaContext()
    {
    }

    public BdPruebaContext(DbContextOptions<BdPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CentroMedico> CentroMedicos { get; set; }

    public virtual DbSet<ConsultaMedica> ConsultaMedicas { get; set; }

    public virtual DbSet<EmpleadoCaja> EmpleadoCajas { get; set; }

    public virtual DbSet<MedicamentosConsultum> MedicamentosConsulta { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<SignosVitale> SignosVitales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BD_Prueba;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CentroMedico>(entity =>
        {
            entity.HasKey(e => e.CentromedicoId).HasName("PK__CENTRO_M__8BA7F53339E72005");

            entity.ToTable("CENTRO_MEDICO");

            entity.Property(e => e.CentromedicoId).HasColumnName("CENTROMEDICO_ID");
            entity.Property(e => e.NombreCentromedico)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CENTROMEDICO");
            entity.Property(e => e.UnidadProgramatica).HasColumnName("UNIDAD_PROGRAMATICA");
        });

        modelBuilder.Entity<ConsultaMedica>(entity =>
        {
            entity.HasKey(e => e.ConsultaId).HasName("PK__CONSULTA__EE0945E64E043CE8");

            entity.ToTable("CONSULTA_MEDICA");

            entity.Property(e => e.ConsultaId).HasColumnName("CONSULTA_ID");
            entity.Property(e => e.Causa)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CAUSA");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DIAGNOSTICO");
            entity.Property(e => e.EmpleadoId).HasColumnName("EMPLEADO_ID");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.MedicamentoId).HasColumnName("MEDICAMENTO_ID");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.PacienteId).HasColumnName("PACIENTE_ID");
            entity.Property(e => e.SignosId).HasColumnName("SIGNOS_ID");
            entity.Property(e => e.Sintomas)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SINTOMAS");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ConsultaMedicas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLEADO");

            //entity.HasOne(d => d.Paciente).WithMany(p => p.ConsultaMedicas)
            //    .HasForeignKey(d => d.PacienteId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PACIENTE");

            entity.HasOne(d => d.Signos).WithMany(p => p.ConsultaMedicas)
                .HasForeignKey(d => d.SignosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SIGNOS");
        });

        modelBuilder.Entity<EmpleadoCaja>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__EMPLEADO__8F0852110ED6EBA2");

            entity.ToTable("EMPLEADO_CAJA");

            entity.Property(e => e.EmpleadoId).HasColumnName("EMPLEADO_ID");
            entity.Property(e => e.Activo).HasColumnName("ACTIVO");
            entity.Property(e => e.CentromedicoId).HasColumnName("CENTROMEDICO_ID");
            entity.Property(e => e.Correo)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.CorreoCaja)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("CORREO_CAJA");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.Identificacion).HasColumnName("IDENTIFICACION");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_USUARIO");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.PuestoId).HasColumnName("PUESTO_ID");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE");
            entity.Property(e => e.ServicioId).HasColumnName("SERVICIO_ID");

            entity.HasOne(d => d.Centromedico).WithMany(p => p.EmpleadoCajas)
                .HasForeignKey(d => d.CentromedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CENTROMEDICO");

            entity.HasOne(d => d.Puesto).WithMany(p => p.EmpleadoCajas)
                .HasForeignKey(d => d.PuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PUESTO");

            entity.HasOne(d => d.Servicio).WithMany(p => p.EmpleadoCajas)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SERVICIO");
        });

        modelBuilder.Entity<MedicamentosConsultum>(entity =>
        {
            entity.HasKey(e => e.MedicamentoId).HasName("PK__MEDICAME__2B5E2685DAE51249");

            entity.ToTable("MEDICAMENTOS_CONSULTA");

            entity.Property(e => e.MedicamentoId).HasColumnName("MEDICAMENTO_ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.ConsultaId).HasColumnName("CONSULTA_ID");
            entity.Property(e => e.Indicaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("INDICACIONES");
            entity.Property(e => e.NombreMedicamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MEDICAMENTO");

            entity.HasOne(d => d.Consulta).WithMany(p => p.MedicamentosConsulta)
                .HasForeignKey(d => d.ConsultaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONSULTA");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.CedulaPaciente).HasName("PK__PACIENTE__FD8C4C6D47802B3E");

            entity.ToTable("PACIENTES");

            entity.Property(e => e.CedulaPaciente)
                .ValueGeneratedNever()
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.Correo)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.Genero)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GENERO");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.ProvinciaId).HasColumnName("PROVINCIA_ID");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE");
            entity.Property(e => e.TelefonoContacto).HasColumnName("TELEFONO_CONTACTO");
            entity.Property(e => e.TelefonoPaciente).HasColumnName("TELEFONO_PACIENTE");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROVINCIA");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__PROVINCI__C7D445C1F07F7D65");

            entity.ToTable("PROVINCIAS");

            entity.Property(e => e.ProvinciaId).HasColumnName("PROVINCIA_ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.PuestoId).HasName("PK__PUESTOS__08F5311F16D78A18");

            entity.ToTable("PUESTOS");

            entity.Property(e => e.PuestoId).HasColumnName("PUESTO_ID");
            entity.Property(e => e.NombrePuesto)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PUESTO");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioId).HasName("PK__SERVICIO__2FC31CD5C22627F3");

            entity.ToTable("SERVICIOS");

            entity.Property(e => e.ServicioId).HasColumnName("SERVICIO_ID");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_SERVICIO");
        });

        modelBuilder.Entity<SignosVitale>(entity =>
        {
            entity.HasKey(e => e.SignosId).HasName("PK__SIGNOS_V__A800E69B32840759");

            entity.ToTable("SIGNOS_VITALES");

            entity.Property(e => e.SignosId).HasColumnName("SIGNOS_ID");
            entity.Property(e => e.Altura).HasColumnName("ALTURA");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.FrecuenciaCardiaca).HasColumnName("FRECUENCIA_CARDIACA");
            entity.Property(e => e.FrecuenciaRespiratoria).HasColumnName("FRECUENCIA_RESPIRATORIA");
            entity.Property(e => e.Peso).HasColumnName("PESO");
            entity.Property(e => e.Temperatura).HasColumnName("TEMPERATURA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
