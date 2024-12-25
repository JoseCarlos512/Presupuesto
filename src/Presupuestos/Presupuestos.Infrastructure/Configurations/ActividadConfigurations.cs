using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presupuestos.Domain.Entities.Actividades;

namespace Presupuestos.Infrastructure.Configurations;

public class ActividadConfigurations : IEntityTypeConfiguration<Actividad>
{
    public void Configure(EntityTypeBuilder<Actividad> builder)
    {
        // Nombre de la tabla
        builder.ToTable("actividad");

        // Clave primaria
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(250)
            .IsUnicode(true); // nvarchar

        builder.Property(a => a.FechaInicio)
            .HasColumnName("fecha_inicio");

        builder.Property(a => a.FechaFin)
            .HasColumnName("fecha_fin");

        builder.Property(a => a.Empleado)
            .HasColumnName("empleado")
            .HasMaxLength(20)
            .IsUnicode(true); // nvarchar

        builder.Property(a => a.Estado)
            .HasColumnName("estado");
        
        // Mapeo de columnas con nombres específicos
        builder.Property(a => a.MacroProcesoId)
            .HasColumnName("id_macro_proceso");

        builder.Property(a => a.ProcesoId)
            .HasColumnName("id_proceso");

        builder.Property(a => a.SubProcesoId)
            .HasColumnName("id_subproceso");

        builder.Property(a => a.Presupuesto)
            .HasColumnName("presupuesto")
            .HasMaxLength(8)
            .IsUnicode(true); // nvarchar

        builder.Property(a => a.Objetivo)
            .HasColumnName("objetivo")
            .HasColumnType("varchar(max)"); // varchar(max)

        builder.Property(a => a.Ubicacion)
            .HasColumnName("ubicacion")
            .HasMaxLength(200)
            .IsUnicode(false); // varchar

        // Relaciones con MacroProceso, Proceso y SubProceso
        builder.HasOne(a => a.MacroProceso)
            .WithMany()
            .HasForeignKey(a => a.MacroProcesoId)
            .HasConstraintName("fk_actividad_macroproceso")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Proceso)
            .WithMany()
            .HasForeignKey(a => a.ProcesoId)
            .HasConstraintName("fk_actividad_proceso")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.SubProceso)
            .WithMany()
            .HasForeignKey(a => a.SubProcesoId)
            .HasConstraintName("fk_actividad_subproceso")
            .OnDelete(DeleteBehavior.Restrict);
    }

}