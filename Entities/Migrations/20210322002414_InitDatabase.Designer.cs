﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entities.Migrations
{
    [DbContext(typeof(CarServiceContext))]
    [Migration("20210322002414_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseSerialColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("ManufacturedMonth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ManufacturedYear")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("RegistrationPlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationPlate")
                        .IsUnique();

                    b.HasIndex("VIN")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Entities.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Entities.Models.ClientCar", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.HasKey("ClientId", "CarId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("ClientCars");
                });

            modelBuilder.Entity("Entities.Models.ClientCar", b =>
                {
                    b.HasOne("Entities.Models.Car", "Car")
                        .WithMany("ClientCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Client", "client")
                        .WithMany("ClientCars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("client");
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.Navigation("ClientCars");
                });

            modelBuilder.Entity("Entities.Models.Client", b =>
                {
                    b.Navigation("ClientCars");
                });
#pragma warning restore 612, 618
        }
    }
}