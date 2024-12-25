using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presupuestos.Domain.Entities.Procesos;

namespace Presupuestos.Infrastructure.Configurations;

public class ProcesoConfigurations : IEntityTypeConfiguration<Proceso>
{
    public void Configure(EntityTypeBuilder<Proceso> builder)
    {
        builder.ToTable("proceso");

        builder.HasKey(p => p.Id);
        
        builder.Property(a => a.MacroProcesoId)
            .HasColumnName("id_macro_proceso");
        
        builder.Property(p => p.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(250)
            .IsUnicode(true); // nvarchar

        builder.HasOne(proceso => proceso.MacroProceso)
            .WithMany()
            .HasForeignKey(proceso => proceso.MacroProcesoId)
            .IsRequired();
    }
}