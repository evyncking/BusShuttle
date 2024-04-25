﻿// <auto-generated />
using ManagerDashboard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagerDashboard.Migrations
{
    [DbContext(typeof(BusShuttleContext))]
    [Migration("20240424212827_AddLoopNameAndStopNameToRouteModel")]
    partial class AddLoopNameAndStopNameToRouteModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ManagerDashboard.Models.BusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BusNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("ManagerDashboard.Models.DriverModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("ManagerDashboard.Models.LoopModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoopName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Loops");
                });

            modelBuilder.Entity("ManagerDashboard.Models.RouteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoopId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StopId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LoopId");

                    b.HasIndex("StopId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("ManagerDashboard.Models.StopModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StopName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("ManagerDashboard.Models.RouteModel", b =>
                {
                    b.HasOne("ManagerDashboard.Models.LoopModel", "Loop")
                        .WithMany()
                        .HasForeignKey("LoopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManagerDashboard.Models.StopModel", "Stop")
                        .WithMany()
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loop");

                    b.Navigation("Stop");
                });
#pragma warning restore 612, 618
        }
    }
}