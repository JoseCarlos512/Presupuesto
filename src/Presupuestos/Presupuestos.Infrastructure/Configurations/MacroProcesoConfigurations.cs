using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presupuestos.Domain.Entities.MacroProcesos;

namespace Presupuestos.Infrastructure.Configurations;

public class MacroProcesoConfigurations : IEntityTypeConfiguration<MacroProceso>
{
    public void Configure(EntityTypeBuilder<MacroProceso> builder)
    {
        builder.ToTable("macro_proceso");

        builder.HasKey(mp => mp.Id);

        builder.Property(mp => mp.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(250)
            .IsUnicode(true); // nvarchar
    }
}