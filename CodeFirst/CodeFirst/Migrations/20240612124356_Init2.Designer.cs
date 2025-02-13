﻿// <auto-generated />
using System;
using CodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirst.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20240612124356_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirst.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor");

                    b.ToTable("doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "jjj@wp.pl",
                            FirstName = "John",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "mj@wp.pl",
                            FirstName = "Maciek",
                            LastName = "Jankowski"
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "no jakis opis 1",
                            Name = "ABC",
                            Type = "no jakis type 1"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "no jakis opis 2",
                            Name = "ABCDD",
                            Type = "no jakis type 2"
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient");

                    b.ToTable("patient");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirthDate = new DateTime(2007, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Johnathan",
                            LastName = "Matejewski"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirthDate = new DateTime(2008, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Natalia",
                            LastName = "Kowalska"
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("prescription");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2008, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2008, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2010, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2010, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("prescription_medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "no jakis details",
                            Dose = 10
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "no jakis details 2",
                            Dose = 20
                        },
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 2,
                            Details = "no jakis details 3",
                            Dose = 5
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.Prescription", b =>
                {
                    b.HasOne("CodeFirst.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirst.Models.Patient", "IdPatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("CodeFirst.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("CodeFirst.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirst.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdMedicamentNavigation");

                    b.Navigation("IdPrescriptionNavigation");
                });

            modelBuilder.Entity("CodeFirst.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("CodeFirst.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("CodeFirst.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("CodeFirst.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
