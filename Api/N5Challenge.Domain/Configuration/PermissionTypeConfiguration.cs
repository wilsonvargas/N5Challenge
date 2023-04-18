using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5Challenge.Domain.Entities;

namespace N5Challenge.Domain.Configuration
{
    public class PermissionTypeConfiguration: IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("TipoPermisos");
            builder.HasData
            (
                new PermissionType
                {
                    Id = 1,
                    Description = "Lectura"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "Escritura"
                }
            );
        }
    }
}