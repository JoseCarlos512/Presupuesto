using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presupuestos.Domain.Entities.SubProcesos;

namespace Presupuestos.Infrastructure.Configurations;

public class SubProcesoConfigurations : IEntityTypeConfiguration<SubProceso>
{
    public void Configure(EntityTypeBuilder<SubProceso> builder)
    {
        builder.ToTable("subproceso");

        builder.HasKey(sp => sp.Id);
        
        builder.Property(a => a.ProcesoId)
            .HasColumnName("id_proceso");
        
        builder.Property(sp => sp.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(250)
            .IsUnicode(true); // nvarchar

        builder.HasOne(subproceso => subproceso.Proceso)
            .WithMany()
            .HasForeignKey(subproceso => subproceso.ProcesoId)
            .IsRequired();
    }
}