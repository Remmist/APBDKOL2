﻿// <auto-generated />
using System;
using APBDKOL2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBDKOL2.Migrations
{
    [DbContext(typeof(RepairDbContext))]
    [Migration("20230606180404_DbDataInsert")]
    partial class DbDataInsert
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBDKOL2.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Make_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationPlate")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Car_pk");

                    b.HasIndex("Make_Id");

                    b.ToTable("Car", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Make_Id = 1,
                            ProductionYear = new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            RegistrationPlate = "A777AA77"
                        },
                        new
                        {
                            Id = 2,
                            Make_Id = 2,
                            ProductionYear = new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            RegistrationPlate = "O777OO77"
                        });
                });

            modelBuilder.Entity("APBDKOL2.Entities.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Make_pk");

                    b.ToTable("Make", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Audi"
                        });
                });

            modelBuilder.Entity("APBDKOL2.Entities.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Specialization_Id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Mechanic_pk");

                    b.HasIndex("Specialization_Id");

                    b.ToTable("Mechanic", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ivan",
                            LastName = "Illarionov",
                            Nickname = "Remmy",
                            Specialization_Id = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Joe",
                            LastName = "Barbaro",
                            Nickname = "Black hand",
                            Specialization_Id = 2
                        });
                });

            modelBuilder.Entity("APBDKOL2.Entities.MechanicCar", b =>
                {
                    b.Property<int>("Mechanic_Id")
                        .HasColumnType("int");

                    b.Property<int>("Car_Id")
                        .HasColumnType("int");

                    b.HasKey("Mechanic_Id", "Car_Id")
                        .HasName("MechanicCar_pk");

                    b.HasIndex("Car_Id");

                    b.ToTable("MechanicCar", (string)null);

                    b.HasData(
                        new
                        {
                            Mechanic_Id = 1,
                            Car_Id = 1
                        },
                        new
                        {
                            Mechanic_Id = 2,
                            Car_Id = 2
                        });
                });

            modelBuilder.Entity("APBDKOL2.Entities.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Specialization_pk");

                    b.ToTable("Specialization", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "EngineMaster"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Engi"
                        });
                });

            modelBuilder.Entity("APBDKOL2.Entities.Car", b =>
                {
                    b.HasOne("APBDKOL2.Entities.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("Make_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Car_Make");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("APBDKOL2.Entities.Mechanic", b =>
                {
                    b.HasOne("APBDKOL2.Entities.Specialization", "Specialization")
                        .WithMany("Mechanics")
                        .HasForeignKey("Specialization_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Mechanic_Specialization");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("APBDKOL2.Entities.MechanicCar", b =>
                {
                    b.HasOne("APBDKOL2.Entities.Car", "Car")
                        .WithMany("MechanicCars")
                        .HasForeignKey("Car_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("MechanicCar_Car");

                    b.HasOne("APBDKOL2.Entities.Mechanic", "Mechanic")
                        .WithMany("MechanicCars")
                        .HasForeignKey("Mechanic_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("MechanicCar_Mechanic");

                    b.Navigation("Car");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("APBDKOL2.Entities.Car", b =>
                {
                    b.Navigation("MechanicCars");
                });

            modelBuilder.Entity("APBDKOL2.Entities.Make", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("APBDKOL2.Entities.Mechanic", b =>
                {
                    b.Navigation("MechanicCars");
                });

            modelBuilder.Entity("APBDKOL2.Entities.Specialization", b =>
                {
                    b.Navigation("Mechanics");
                });
#pragma warning restore 612, 618
        }
    }
}
