﻿// <auto-generated />
using System;
using GestorDePacientes.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231016232923_AutoInsertData")]
    partial class AutoInsertData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.AppoinmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppoinmentStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creaty = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "PENDIENTE DE CONSULTA",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Creaty = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "PENDIENTE DE RESULTADOS",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Creaty = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "COMPLETADA",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Identification")
                        .IsUnique();

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.LabTests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LabTests", (string)null);
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.MedicalAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfAppoinment")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HourOfAppoinment")
                        .HasColumnType("time");

                    b.Property<int>("IdAppoinmentStatus")
                        .HasColumnType("int");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonOfAppoinment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAppoinmentStatus");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("MedicalAppointment", (string)null);
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBorn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAllegier")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSmoker")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Identification")
                        .IsUnique();

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.PatientLabTests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLabTests")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicalAppoinment")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdLabTests");

                    b.HasIndex("IdMedicalAppoinment");

                    b.HasIndex("IdPatient");

                    b.ToTable("PatientLabTests", (string)null);
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creaty = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = 2,
                            Creaty = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ASISTENTE"
                        });
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creaty")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdRol");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.MedicalAppointment", b =>
                {
                    b.HasOne("GestorDePacientes.Core.Domain.Entities.AppoinmentStatus", "AppoinmentStatus")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("IdAppoinmentStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorDePacientes.Core.Domain.Entities.Doctor", "Doctor")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorDePacientes.Core.Domain.Entities.Patient", "Patient")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppoinmentStatus");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.PatientLabTests", b =>
                {
                    b.HasOne("GestorDePacientes.Core.Domain.Entities.LabTests", "LabTests")
                        .WithMany("PatientLabTests")
                        .HasForeignKey("IdLabTests")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorDePacientes.Core.Domain.Entities.MedicalAppointment", "MedicalAppointment")
                        .WithMany("PatientLabTests")
                        .HasForeignKey("IdMedicalAppoinment")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GestorDePacientes.Core.Domain.Entities.Patient", "Patient")
                        .WithMany("PatientLabTests")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LabTests");

                    b.Navigation("MedicalAppointment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("GestorDePacientes.Core.Domain.Entities.Rol", "Rol")
                        .WithMany("Users")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.AppoinmentStatus", b =>
                {
                    b.Navigation("MedicalAppointments");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("MedicalAppointments");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.LabTests", b =>
                {
                    b.Navigation("PatientLabTests");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.MedicalAppointment", b =>
                {
                    b.Navigation("PatientLabTests");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.Patient", b =>
                {
                    b.Navigation("MedicalAppointments");

                    b.Navigation("PatientLabTests");
                });

            modelBuilder.Entity("GestorDePacientes.Core.Domain.Entities.Rol", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
