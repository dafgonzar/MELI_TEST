using MeliTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeliTest.Infrastructure.Data.Configurations
{
    class ContainersConfigurations : IEntityTypeConfiguration<TbContenedores>
    {
        public void Configure(EntityTypeBuilder<TbContenedores> entity)
        {
            //-- Para MySql  --//

            entity.HasKey(e => e.NombreContenedor);

            entity.ToTable("TbContenedores");

            entity.Property(e => e.NombreContenedor)
                .HasColumnName("NombreContenedor")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ValorContainer)
                .HasColumnType("DECIMAL")
                .HasColumnName("ValorContainer");

            entity.Property(e => e.CostoTransporte)
                .HasColumnType("DECIMAL")
                .HasColumnName("CostoTransporte");

        }
    }
}
