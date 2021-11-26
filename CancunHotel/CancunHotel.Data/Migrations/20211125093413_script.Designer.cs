﻿// <auto-generated />
using System;
using CancunHotel.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CancunHotel.Data.Migrations
{
    [DbContext(typeof(CancunHotelContext))]
    [Migration("20211125093413_script")]
    partial class script
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CancunHotel.Domain.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("bit")
                        .HasColumnName("Cancelled");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CheckIn");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2")
                        .HasColumnName("CheckOut");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedIn");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoomId");

                    b.Property<DateTime?>("UpdatedIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedIn");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CancunHotel.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<bool>("ChangePassword")
                        .HasColumnType("bit")
                        .HasColumnName("ChangePassword");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedIn");

                    b.Property<string>("DocumentNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DocumentNumber");

                    b.Property<string>("EMail")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("EMail");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Password");

                    b.Property<DateTime?>("UpdatedIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedIn");

                    b.Property<int>("UserAccessLevel")
                        .HasColumnType("int")
                        .HasColumnName("UserAccessLevel");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CancunHotel.Domain.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedIn");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Floor")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Floor");

                    b.Property<string>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Number");

                    b.Property<DateTime?>("UpdatedIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedIn");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("CancunHotel.Domain.Models.Booking", b =>
                {
                    b.HasOne("CancunHotel.Domain.Models.Customer", "Customer")
                        .WithMany("Booking")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CancunHotel.Domain.Models.Room", "Room")
                        .WithMany("Booking")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("CancunHotel.Domain.Models.Customer", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("CancunHotel.Domain.Models.Room", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}
