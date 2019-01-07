﻿// <auto-generated />
using System;
using CPMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPMS.DAL.Migrations
{
    [DbContext(typeof(ManagementSystemContext))]
    partial class ManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPMS.DAL.DTO.AddressDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<int>("ZIP");

                    b.HasKey("ID");

                    b.ToTable("Addresses","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.BillingInfoDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressID");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("DIC")
                        .IsRequired();

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("ICO")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("BillingInfos","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.CommentDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeveloperID");

                    b.Property<int?>("TaskDTOID");

                    b.Property<int>("TaskID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("TaskDTOID");

                    b.ToTable("Comments","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.CustomerDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BillingInfoID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("BillingInfoID");

                    b.ToTable("Customers","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.DeveloperDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Developers","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.InvoiceDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<decimal>("ManHour");

                    b.Property<int>("PersonID");

                    b.Property<decimal>("Time");

                    b.HasKey("ID");

                    b.ToTable("Invoices","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.ProjectDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("StarDate");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Projects","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.TaskDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CloseDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Point");

                    b.Property<int?>("ProjectDTOID");

                    b.Property<int>("ProjectID");

                    b.Property<DateTime>("StarDate");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("ProjectDTOID");

                    b.ToTable("Tasks","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.TimeDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Close");

                    b.Property<string>("Description");

                    b.Property<int?>("InvoiceDTOID");

                    b.Property<int?>("InvoiceID");

                    b.Property<int>("PersonID");

                    b.Property<DateTime>("Start");

                    b.Property<int>("TaskID");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceDTOID");

                    b.ToTable("Times","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.BillingInfoDTO", b =>
                {
                    b.HasOne("CPMS.DAL.DTO.AddressDTO", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.DAL.DTO.CommentDTO", b =>
                {
                    b.HasOne("CPMS.DAL.DTO.TaskDTO")
                        .WithMany("Comments")
                        .HasForeignKey("TaskDTOID");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.CustomerDTO", b =>
                {
                    b.HasOne("CPMS.DAL.DTO.BillingInfoDTO", "BillingInfo")
                        .WithMany()
                        .HasForeignKey("BillingInfoID");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.ProjectDTO", b =>
                {
                    b.HasOne("CPMS.DAL.DTO.CustomerDTO", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.DAL.DTO.TaskDTO", b =>
                {
                    b.HasOne("CPMS.DAL.DTO.ProjectDTO")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectDTOID");
                });

            modelBuilder.Entity("CPMS.DAL.DTO.TimeDTO", b =>
                {
                    b.HasOne("CPMS.DAL.DTO.InvoiceDTO")
                        .WithMany("TimeSpent")
                        .HasForeignKey("InvoiceDTOID");
                });
#pragma warning restore 612, 618
        }
    }
}
