﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muhasebecini.Entities;

#nullable disable

namespace Muhasebecini.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230312153250_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Muhasebecini.Entities.AccountantInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<byte[]>("Image")
                        .HasColumnType("VARBINARY(MAX)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Phone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Surname");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accountant_Info", (string)null);

                    b.HasComment("Muhasebeci Bilgileri");
                });

            modelBuilder.Entity("Muhasebecini.Entities.CommendInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountantId")
                        .HasColumnType("int");

                    b.Property<string>("Commend")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Commend");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountantId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Commend_Info", (string)null);

                    b.HasComment("Yorum Bilgileri");
                });

            modelBuilder.Entity("Muhasebecini.Entities.CustomerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.ToTable("Customer_Info", (string)null);

                    b.HasComment("Müşteri Bilgileri");
                });

            modelBuilder.Entity("Muhasebecini.Entities.CommendInfo", b =>
                {
                    b.HasOne("Muhasebecini.Entities.AccountantInfo", "AccountantInfo")
                        .WithMany("CommendInfos")
                        .HasForeignKey("AccountantId")
                        .IsRequired()
                        .HasConstraintName("Accountant_Id_Fkey");

                    b.HasOne("Muhasebecini.Entities.CustomerInfo", "CustomerInfo")
                        .WithMany("CommendInfos")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("Customer_Id_Fkey");

                    b.Navigation("AccountantInfo");

                    b.Navigation("CustomerInfo");
                });

            modelBuilder.Entity("Muhasebecini.Entities.AccountantInfo", b =>
                {
                    b.Navigation("CommendInfos");
                });

            modelBuilder.Entity("Muhasebecini.Entities.CustomerInfo", b =>
                {
                    b.Navigation("CommendInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
