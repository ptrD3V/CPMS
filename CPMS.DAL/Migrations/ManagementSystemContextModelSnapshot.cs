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
                ;

            modelBuilder.Entity("CPMS.DAL.DAO.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

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

            modelBuilder.Entity("CPMS.DAL.DAO.BillingInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

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

                    b.Property<int>("PersonID");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("BillingInfos","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

                    b.Property<int>("DeveloperID");

                    b.Property<int>("TaskID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("TaskID");

                    b.ToTable("Comments","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

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

            modelBuilder.Entity("CPMS.DAL.DAO.Developer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Developers","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

                    b.Property<DateTime>("CreateDate");

                    b.Property<decimal>("ManHour");

                    b.Property<int>("PersonID");

                    b.Property<decimal>("Time");

                    b.HasKey("ID");

                    b.ToTable("Invoices","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PersonID");

                    b.Property<DateTime>("StarDate");

                    b.HasKey("ID");

                    b.ToTable("Projects","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

                    b.Property<DateTime?>("CloseDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Point");

                    b.Property<int>("ProjectID");

                    b.Property<DateTime>("StarDate");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Tasks","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Time", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        ;

                    b.Property<DateTime?>("Close");

                    b.Property<string>("Description");

                    b.Property<int?>("InvoiceID");

                    b.Property<int>("PersonID");

                    b.Property<DateTime>("Start");

                    b.Property<int>("TaskID");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("Times","cpms");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.BillingInfo", b =>
                {
                    b.HasOne("CPMS.DAL.DAO.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Comment", b =>
                {
                    b.HasOne("CPMS.DAL.DAO.Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Customer", b =>
                {
                    b.HasOne("CPMS.DAL.DAO.BillingInfo", "BillingInfo")
                        .WithMany()
                        .HasForeignKey("BillingInfoID");
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Task", b =>
                {
                    b.HasOne("CPMS.DAL.DAO.Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CPMS.DAL.DAO.Time", b =>
                {
                    b.HasOne("CPMS.DAL.DAO.Invoice")
                        .WithMany("TimeSpent")
                        .HasForeignKey("InvoiceID");
                });
#pragma warning restore 612, 618
        }
    }
}
