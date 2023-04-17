﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5Challenge.Domain;

namespace N5Challenge.Domain.Migrations
{
    [DbContext(typeof(N5ChallengeDbContext))]
    partial class N5ChallengeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("N5Challenge.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeLastName")
                        .HasColumnName("ApellidoEmpleado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnName("NombreEmpleado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PermissionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FechaPermiso")
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 4, 14, 22, 38, 53, 626, DateTimeKind.Local).AddTicks(3756));

                    b.Property<int>("PermissionTypeId")
                        .HasColumnName("TipoPermiso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("Permisos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeLastName = "Doe",
                            EmployeeName = "John",
                            PermissionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeLastName = "Miles",
                            EmployeeName = "Mike",
                            PermissionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            EmployeeLastName = "Laurence",
                            EmployeeName = "William",
                            PermissionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionTypeId = 2
                        });
                });

            modelBuilder.Entity("N5Challenge.Domain.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoPermisos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lectura"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Escritura"
                        });
                });

            modelBuilder.Entity("N5Challenge.Domain.Entities.Permission", b =>
                {
                    b.HasOne("N5Challenge.Domain.Entities.PermissionType", "PermissionType")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
