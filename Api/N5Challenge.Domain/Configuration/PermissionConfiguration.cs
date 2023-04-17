using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5Challenge.Domain.Entities;

namespace N5Challenge.Domain.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permisos");
            builder.Property(s => s.PermissionDate)
                .HasDefaultValue(DateTime.Now);
            builder.HasData
            (
                new Permission
                {
                    Id = 1,
                    EmployeeName = "John",
                    EmployeeLastName = "Doe",
                    PermissionTypeId = 1
                },
                new Permission
                {
                    Id = 2,
                    EmployeeName = "Mike",
                    EmployeeLastName = "Miles",
                    PermissionTypeId = 1
                },
                new Permission
                {
                    Id = 3,
                    EmployeeName = "William",
                    EmployeeLastName = "Laurence",
                    PermissionTypeId = 2
                }
            );
        }
    }
}